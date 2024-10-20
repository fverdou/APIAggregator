using Newtonsoft.Json;

namespace APIAggregator.Models
{
    public class WordApiResponse
    {
        [JsonProperty("word")]
        public string Word { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }

        [JsonProperty("syllables")]
        public Syllables Syllables { get; set; }

        [JsonProperty("pronunciation")]
        public Pronunciation Pronunciation { get; set; }

        [JsonProperty("frequency")]
        public double Frequency { get; set; }
    }

    public class Result
    {
        [JsonProperty("definition")]
        public string Definition { get; set; }

        [JsonProperty("partOfSpeech")]
        public string PartOfSpeech { get; set; }

        [JsonProperty("synonyms")]
        public List<string> Synonyms { get; set; }

        [JsonProperty("typeOf")]
        public List<string> TypeOf { get; set; }

        [JsonProperty("hasTypes")]
        public List<string> HasTypes { get; set; }

        [JsonProperty("derivation")]
        public List<string> Derivation { get; set; }

        [JsonProperty("examples")]
        public List<string> Examples { get; set; }
    }

    public class Syllables
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("list")]
        public List<string> List { get; set; }
    }

    public class Pronunciation
    {
        [JsonProperty("all")]
        public string All { get; set; }
    }
}
