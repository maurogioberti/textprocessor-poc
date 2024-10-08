﻿using Poc.TextProcessor.CrossCutting.Utils.Mapper;
using Poc.TextProcessor.ResourceAccess.Database.Abstractions;
using Poc.TextProcessor.ResourceAccess.Domains;
using Poc.TextProcessor.ResourceAccess.Entities;
using Poc.TextProcessor.ResourceAccess.Repositories.Abstractions;
using Poc.TextProcessor.ResourceAccess.Repositories.Base;

namespace Poc.TextProcessor.ResourceAccess.Repositories
{
    public class TextSortRepository(IDatabaseReaderProvider databaseProvider) : RepositoryReaderBase(databaseProvider), ITextSortRepository
    {
        public IEnumerable<TextSort> List()
        {
            var textSorts = _databaseProvider.Get<TextSortEntity>().ToList();
            return AutoMap.Map<TextSortEntity, TextSort>(textSorts);
        }
    }
}