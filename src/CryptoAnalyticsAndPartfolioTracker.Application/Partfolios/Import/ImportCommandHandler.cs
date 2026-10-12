using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Parser;
using MediatR;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Partfolios.Import
{
    public class ImportCommandHandler : IRequestHandler<ImportCommand>
    {
        private readonly IParserSolver _solver;
        private readonly IImporter _importer;

        public ImportCommandHandler(IParserSolver solver, IImporter importer)
        {
            _solver = solver;
            _importer = importer;
        }

        public async Task Handle(ImportCommand request, CancellationToken cancellationToken)
        {

            foreach (var file in request.Files)
            {
                var parser = _solver.Solve(file.ContentType);

                var document = parser.Parse(file.Stream);

                if (!_importer.IsHandle(document))
                    throw new InvalidDataException("Unsupported data format");

                await _importer.ImportAsync(document, request.UserId, cancellationToken);
            }
        }
    }
}