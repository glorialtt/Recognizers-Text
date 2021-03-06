﻿using System.Collections.Immutable;
using System.Text.RegularExpressions;

using Microsoft.Recognizers.Text.Number.Config;

namespace Microsoft.Recognizers.Text.Number.Japanese
{

    public class NumberExtractor : BaseNumberExtractor
    {
        public NumberExtractor(CJKNumberExtractorMode mode = CJKNumberExtractorMode.Default)
        {
            var builder = ImmutableDictionary.CreateBuilder<Regex, TypeTag>();

            // Add Cardinal
            var cardExtract = new CardinalExtractor(mode);
            builder.AddRange(cardExtract.Regexes);

            // Add Fraction
            var fracExtract = new FractionExtractor();
            builder.AddRange(fracExtract.Regexes);

            Regexes = builder.ToImmutable();
        }

        internal sealed override ImmutableDictionary<Regex, TypeTag> Regexes { get; }

        protected sealed override string ExtractType { get; } = Constants.SYS_NUM;
    }
}
