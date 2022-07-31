namespace Json.Song1
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [Serializable]
    public class ScoreJson
    {
        [JsonProperty("score", NullValueHandling = NullValueHandling.Ignore)]
        public Score score;
        public static ScoreJson FromJson(string json) => JsonConvert.DeserializeObject<ScoreJson>(json, Converter.Settings);

    }

    [Serializable]
    public partial class Score
    {

        [JsonProperty("infos", NullValueHandling = NullValueHandling.Ignore)]
        public Infos Infos;

        [JsonProperty("timeline", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DecodeArrayConverter))]
        public long[] Timeline;

        [JsonProperty("measure", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, The1_Value> Measure;

        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Note> Note;

        [JsonProperty("rightHand", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, RightHand> RightHand;

        [JsonProperty("leftHand", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, LeftHand> LeftHand;

        [JsonProperty("lyricsTimeline", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DecodeArrayConverter))]
        public long[] LyricsTimeline;

        [JsonProperty("lyricsMeasure", NullValueHandling = NullValueHandling.Ignore)]
        public Measure LyricsMeasure;

        [JsonProperty("lyricsNote", NullValueHandling = NullValueHandling.Ignore)]
        public LyricsNote LyricsNote;

        [JsonProperty("harmonyTimeline", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DecodeArrayConverter))]
        public long[] HarmonyTimeline;

        [JsonProperty("harmonyMeasure", NullValueHandling = NullValueHandling.Ignore)]
        public Measure HarmonyMeasure;

        [JsonProperty("harmonyNote", NullValueHandling = NullValueHandling.Ignore)]
        public HarmonyNote HarmonyNote;

        [JsonProperty("harmonyLeftHand", NullValueHandling = NullValueHandling.Ignore)]
        public object[] HarmonyLeftHand;

        [JsonProperty("rhythmTimeline", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DecodeArrayConverter))]
        public long[] RhythmTimeline;

        [JsonProperty("rhythmMeasure", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, The1_Value> RhythmMeasure;

        [JsonProperty("rhythmNote", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, RhythmNote> RhythmNote;
    }

    [Serializable]
    public partial class Measure
    {
        [JsonProperty("1", NullValueHandling = NullValueHandling.Ignore)]
        public The1_Value The1;
    }

    [Serializable]
    public partial class The1_Value
    {
        [JsonProperty("bpm", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Bpm;


        [JsonProperty("beat", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Beat;

        [JsonProperty("beatType", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? BeatType;

        [JsonProperty("notes", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DecodeArrayConverter))]
        public long[] Notes;

        [JsonProperty("sectionName", NullValueHandling = NullValueHandling.Ignore)]
        public string SectionName;
    }

    [Serializable]
    public partial class HarmonyNote
    {
        [JsonProperty("1", NullValueHandling = NullValueHandling.Ignore)]
        public HarmonyNote1 The1;
    }

    [Serializable]
    public partial class HarmonyNote1
    {
        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public long? Time;

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public TypeEnum? Type;

        [JsonProperty("chordName", NullValueHandling = NullValueHandling.Ignore)]
        public string ChordName;

        [JsonProperty("stringPlayed", NullValueHandling = NullValueHandling.Ignore)]
        public object[] StringPlayed;

        [JsonProperty("leftHand", NullValueHandling = NullValueHandling.Ignore)]
        public object[] LeftHand;

        [JsonProperty("signature", NullValueHandling = NullValueHandling.Ignore)]
        public string Signature;
    }

    [Serializable]
    public partial class Infos
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title;

        [JsonProperty("artist", NullValueHandling = NullValueHandling.Ignore)]
        public string Artist;

        [JsonProperty("guitarType", NullValueHandling = NullValueHandling.Ignore)]
        public string GuitarType;

        [JsonProperty("tuning", NullValueHandling = NullValueHandling.Ignore)]
        public Tuning[] Tuning;

        [JsonProperty("capo", NullValueHandling = NullValueHandling.Ignore)]
        public string Capo;
    }

    [Serializable]
    public partial class Tuning
    {
        [JsonProperty("string", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? String;

        [JsonProperty("pitch", NullValueHandling = NullValueHandling.Ignore)]
        public string Pitch;
    }

    [Serializable]
    public partial class LeftHand
    {
        [JsonProperty("pitch", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Pitch;

        [JsonProperty("fingering", NullValueHandling = NullValueHandling.Ignore)]
        public Fingering? Fingering;

        [JsonProperty("fret", NullValueHandling = NullValueHandling.Ignore)]
        public long? Fret;

        [JsonProperty("string", NullValueHandling = NullValueHandling.Ignore)]
        public long? String;

        [JsonProperty("bar")]
        public object Bar;
    }

    [Serializable]
    public partial class LyricsNote
    {
        [JsonProperty("1", NullValueHandling = NullValueHandling.Ignore)]
        public LyricsNote1 The1;
    }

    [Serializable]
    public partial class LyricsNote1
    {
        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public long? Time;

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public TypeEnum? Type;

        [JsonProperty("lyrics", NullValueHandling = NullValueHandling.Ignore)]
        public string Lyrics;

        [JsonProperty("tie", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Tie;

        [JsonProperty("endSentence", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EndSentence;

        [JsonProperty("isSilence", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsSilence;
    }

    [Serializable]
    public partial class Note
    {
        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public double? Time;

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public TypeEnum? Type;

        [JsonProperty("leftHand", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DecodeArrayConverter))]
        public long[] LeftHand;

        [JsonProperty("rightHand", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DecodeArrayConverter))]
        public long[] RightHand;

        [JsonProperty("tiedString", NullValueHandling = NullValueHandling.Ignore)]
        public long[] TiedString;

        [JsonProperty("newStartMovement", NullValueHandling = NullValueHandling.Ignore)]
        public string NewStartMovement;

         [JsonProperty("isRepeatMode", NullValueHandling = NullValueHandling.Ignore)]
        public bool? isRepeatMode;






       
    }

    [Serializable]
    public partial class RhythmNote
    {
        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public long? Time;

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public TypeEnum? Type;

        [JsonProperty("lyrics", NullValueHandling = NullValueHandling.Ignore)]
        public string Lyrics;
    }

    [Serializable]
    public partial class RightHand
    {
        [JsonProperty("string", NullValueHandling = NullValueHandling.Ignore)]
        public long? String;

        [JsonProperty("strock", NullValueHandling = NullValueHandling.Ignore)]
        public string Strock;
    }

    [Serializable]
    public enum TypeEnum { Eighth, Half, Quarter, Whole };

    [Serializable]
    public enum Fingering { A, C, I, M };





    public static class Serialize
    {
        public static string ToJson(this ScoreJson self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypeEnumConverter.Singleton,
                FingeringConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class DecodeArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long[]);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            reader.Read();
            var value = new List<long>();
            while (reader.TokenType != JsonToken.EndArray)
            {
                var converter = ParseStringConverter.Singleton;
                var arrayItem = (long)converter.ReadJson(reader, typeof(long), null, serializer);
                value.Add(arrayItem);
                reader.Read();
            }
            return value.ToArray();
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (long[])untypedValue;
            writer.WriteStartArray();
            foreach (var arrayItem in value)
            {
                var converter = ParseStringConverter.Singleton;
                converter.WriteJson(writer, arrayItem, serializer);
            }
            writer.WriteEndArray();
            return;
        }

        public static readonly DecodeArrayConverter Singleton = new DecodeArrayConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "eighth":
                    return TypeEnum.Eighth;
                case "half":
                    return TypeEnum.Half;
                case "quarter":
                    return TypeEnum.Quarter;
                case "whole":
                    return TypeEnum.Whole;
                case "16th":
                    return TypeEnum.Eighth;// добавил
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Eighth:
                    serializer.Serialize(writer, "eighth");
                    return;
                case TypeEnum.Half:
                    serializer.Serialize(writer, "half");
                    return;
                case TypeEnum.Quarter:
                    serializer.Serialize(writer, "quarter");
                    return;
                case TypeEnum.Whole:
                    serializer.Serialize(writer, "whole");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }

    internal class FingeringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Fingering) || t == typeof(Fingering?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "a":
                    return Fingering.A;
                case "c":
                    return Fingering.C;
                case "i":
                    return Fingering.I;
                case "m":
                    return Fingering.M;
            }
            throw new Exception("Cannot unmarshal type Fingering");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Fingering)untypedValue;
            switch (value)
            {
                case Fingering.A:
                    serializer.Serialize(writer, "a");
                    return;
                case Fingering.C:
                    serializer.Serialize(writer, "c");
                    return;
                case Fingering.I:
                    serializer.Serialize(writer, "i");
                    return;
                case Fingering.M:
                    serializer.Serialize(writer, "m");
                    return;
            }
            throw new Exception("Cannot marshal type Fingering");
        }

        public static readonly FingeringConverter Singleton = new FingeringConverter();
    }
}
