﻿//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------
namespace Microsoft.Azure.Cosmos.Json
{
    using System;
    using Microsoft.Azure.Cosmos.Core.Utf8;

    /// <summary>
    /// Interface for all JsonWriters that know how to write jsons of a specific serialization format.
    /// </summary>
#if INTERNAL
    public
#else
    internal
#endif
    interface IJsonWriter
    {
        /// <summary>
        /// Gets the SerializationFormat of the JsonWriter.
        /// </summary>
        JsonSerializationFormat SerializationFormat { get; }

        /// <summary>
        /// Gets the current length of the internal buffer.
        /// </summary>
        long CurrentLength { get; }

        /// <summary>
        /// Writes the object start symbol to internal buffer.
        /// </summary>
        void WriteObjectStart();

        /// <summary>
        /// Writes the object end symbol to the internal buffer.
        /// </summary>
        void WriteObjectEnd();

        /// <summary>
        /// Writes the array start symbol to the internal buffer.
        /// </summary>
        void WriteArrayStart();

        /// <summary>
        /// Writes the array end symbol to the internal buffer.
        /// </summary>
        void WriteArrayEnd();

        /// <summary>
        /// Writes a field name to the the internal buffer.
        /// </summary>
        /// <param name="fieldName">The name of the field to write.</param>
        /// <param name="skipEscapedStringChecks">Whether or not to skip checks for escaped strings.</param>
        void WriteFieldName(string fieldName, bool skipEscapedStringChecks = false);

        /// <summary>
        /// Writes a UTF-8 field name to the internal buffer.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="skipEscapedStringChecks">Whether or not to skip checks for escaped strings.</param>
        void WriteFieldName(Utf8Span fieldName, bool skipEscapedStringChecks = false);

        /// <summary>
        /// Writes a string to the internal buffer.
        /// </summary>
        /// <param name="value">The value of the string to write.</param>
        /// <param name="skipEscapedStringChecks">Whether or not to skip checks for escaped strings.</param>
        void WriteStringValue(string value, bool skipEscapedStringChecks = false);

        /// <summary>
        /// Writes a UTF-8 string value to the internal buffer.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="skipEscapedStringChecks">Whether or not to skip checks for escaped strings.</param>
        void WriteStringValue(Utf8Span value, bool skipEscapedStringChecks = false);

        /// <summary>
        /// Writes a number to the internal buffer.
        /// </summary>
        /// <param name="value">The value of the number to write.</param>
        void WriteNumber64Value(Number64 value);

        /// <summary>
        /// Writes a boolean to the internal buffer.
        /// </summary>
        /// <param name="value">The value of the boolean to write.</param>
        void WriteBoolValue(bool value);

        /// <summary>
        /// Writes a null to the internal buffer.
        /// </summary>
        void WriteNullValue();

        /// <summary>
        /// Writes an single signed byte integer to the internal buffer.
        /// </summary>
        /// <param name="value">The value of the integer to write.</param>
        void WriteInt8Value(sbyte value);

        /// <summary>
        /// Writes an signed 2-byte integer to the internal buffer.
        /// </summary>
        /// <param name="value">The value of the integer to write.</param>
        void WriteInt16Value(short value);

        /// <summary>
        /// Writes an signed 4-byte integer to the internal buffer.
        /// </summary>
        /// <param name="value">The value of the integer to write.</param>
        void WriteInt32Value(int value);

        /// <summary>
        /// Writes an signed 8-byte integer to the internal buffer.
        /// </summary>
        /// <param name="value">The value of the integer to write.</param>
        void WriteInt64Value(long value);

        /// <summary>
        /// Writes a single precision floating point number into the internal buffer.
        /// </summary>
        /// <param name="value">The value of the integer to write.</param>
        void WriteFloat32Value(float value);

        /// <summary>
        /// Writes a double precision floating point number into the internal buffer.
        /// </summary>
        /// <param name="value">The value of the integer to write.</param>
        void WriteFloat64Value(double value);

        /// <summary>
        /// Writes a 4 byte unsigned integer into the internal buffer.
        /// </summary>
        /// <param name="value">The value of the integer to write.</param>
        void WriteUInt32Value(uint value);

        /// <summary>
        /// Writes a Guid value into the internal buffer.
        /// </summary>
        /// <param name="value">The value of the guid to write.</param>
        void WriteGuidValue(Guid value);

        /// <summary>
        /// Writes a Binary value into the internal buffer.
        /// </summary>
        /// <param name="value">The value of the bytes to write.</param>
        void WriteBinaryValue(ReadOnlySpan<byte> value);

        /// <summary>
        /// Writes current token from a json reader to the internal buffer.
        /// </summary>
        /// <param name="jsonReader">The JsonReader to the get the current token from.</param>
        void WriteCurrentToken(IJsonReader jsonReader);

        /// <summary>
        /// Writes every token from the JsonReader to the internal buffer.
        /// </summary>
        /// <param name="jsonReader">The JsonReader to get the tokens from.</param>
        void WriteAll(IJsonReader jsonReader);

        /// <summary>
        /// Writes a fragment of a json to the internal buffer
        /// </summary>
        /// <param name="jsonFragment">A section of a valid json</param>
        void WriteJsonFragment(ReadOnlyMemory<byte> jsonFragment);

        /// <summary>
        /// Writes a raw JSON token to the writer.
        /// </summary>
        /// <remarks>The raw json token has to be the same format.</remarks>
        /// <param name="jsonTokenType">The type of jsonToken to write.</param>
        /// <param name="rawJsonToken">The JSON token to write.</param>
        void WriteRawJsonToken(JsonTokenType jsonTokenType, ReadOnlySpan<byte> rawJsonToken);

        /// <summary>
        /// Gets the result of the JsonWriter.
        /// </summary>
        /// <returns>The result of the JsonWriter as an array of bytes.</returns>
        ReadOnlyMemory<byte> GetResult();
    }
}
