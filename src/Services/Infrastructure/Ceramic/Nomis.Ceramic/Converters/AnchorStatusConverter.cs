// ------------------------------------------------------------------------------------------------------
// <copyright file="AnchorStatusConverter.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json;
using System.Text.Json.Serialization;

using Nomis.Ceramic.Interfaces.Enums;

namespace Nomis.Ceramic.Converters
{
    internal sealed class AnchorStatusConverter :
        JsonConverter<AnchorStatus?>
    {
        /// <inheritdoc/>
        public override AnchorStatus? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException($"Found token {reader.TokenType} but expected token {JsonTokenType.Number}");
            }

            using var doc = JsonDocument.ParseValue(ref reader);
            if (Enum.TryParse<AnchorStatus>(doc.RootElement.ToString(), true, out var anchorStatus))
            {
                return anchorStatus;
            }

            return null;
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, AnchorStatus? value, JsonSerializerOptions options) =>
            writer.WriteRawValue(value?.ToString() ?? nameof(AnchorStatus.NOT_REQUESTED), false);
    }
}