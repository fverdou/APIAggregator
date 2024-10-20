using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using System.Reflection.Emit;

namespace APIAggregator.Models
{
    public class SpotifyApiResponse
    {
        [JsonProperty("albums")]
        public Albums Albums { get; set; }

        [JsonProperty("artists")]
        public WelcomeArtists Artists { get; set; }

        [JsonProperty("episodes")]
        public Episodes Episodes { get; set; }

        [JsonProperty("genres")]
        public Genres Genres { get; set; }

        [JsonProperty("playlists")]
        public Playlists Playlists { get; set; }

        [JsonProperty("podcasts")]
        public Podcasts Podcasts { get; set; }

        [JsonProperty("topResults")]
        public TopResults TopResults { get; set; }

        [JsonProperty("tracks")]
        public Tracks Tracks { get; set; }

        [JsonProperty("users")]
        public Users Users { get; set; }
    }

    public class Albums
    {
        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }

        [JsonProperty("items")]
        public List<AlbumItem> Items { get; set; }
    }

    public class AlbumItem
    {
        [JsonProperty("data")]
        public AlbumData Data { get; set; }
    }

    public class AlbumData
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("artists")]
        public Artists Artists { get; set; }

        [JsonProperty("coverArt")]
        public CoverArt CoverArt { get; set; }

        [JsonProperty("date")]
        public Date Date { get; set; }
    }

    public class Artists
    {
        [JsonProperty("items")]
        public List<ArtistData> Items { get; set; }
    }

    public class ArtistData
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }
    }

    public class Profile
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class CoverArt
    {
        [JsonProperty("sources")]
        public List<Source> Sources { get; set; }
    }

    public class Source
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("width")]
        public long? Width { get; set; }

        [JsonProperty("height")]
        public long? Height { get; set; }
    }

    public class Date
    {
        [JsonProperty("year")]
        public long Year { get; set; }
    }

    public class WelcomeArtists
    {
        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }

        [JsonProperty("items")]
        public List<ArtistsItem> Items { get; set; }
    }

    public class ArtistsItem
    {
        [JsonProperty("data")]
        public ArtistsData Data { get; set; }
    }

    public class ArtistsData
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }

        [JsonProperty("visuals")]
        public Visuals Visuals { get; set; }
    }

    public class Visuals
    {
        [JsonProperty("avatarImage")]
        public CoverArt AvatarImage { get; set; }
    }

    public class Episodes
    {
        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }

        [JsonProperty("items")]
        public List<EpisodesItem> Items { get; set; }
    }

    public class EpisodesItem
    {
        [JsonProperty("data")]
        public EpisodesData Data { get; set; }
    }

    public class EpisodesData
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coverArt")]
        public CoverArt CoverArt { get; set; }

        [JsonProperty("duration")]
        public Duration Duration { get; set; }

        [JsonProperty("releaseDate")]
        public ReleaseDate ReleaseDate { get; set; }

        [JsonProperty("podcast")]
        public Podcast Podcast { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("contentRating")]
        public ContentRating ContentRating { get; set; }
    }

    public class ContentRating
    {
        [JsonProperty("label")]
        public Label Label { get; set; }
    }

    public class Duration
    {
        [JsonProperty("totalMilliseconds")]
        public long TotalMilliseconds { get; set; }
    }

    public class Podcast
    {
        [JsonProperty("coverArt")]
        public CoverArt CoverArt { get; set; }
    }

    public class ReleaseDate
    {
        [JsonProperty("isoString")]
        public DateTimeOffset IsoString { get; set; }
    }

    public class Genres
    {
        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }

        [JsonProperty("items")]
        public List<GenresItem> Items { get; set; }
    }

    public class GenresItem
    {
        [JsonProperty("data")]
        public GenresData Data { get; set; }
    }

    public class GenresData
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public CoverArt Image { get; set; }
    }

    public class Playlists
    {
        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }

        [JsonProperty("items")]
        public List<PlaylistsItem> Items { get; set; }
    }

    public class PlaylistsItem
    {
        [JsonProperty("data")]
        public PlaylistData Data { get; set; }
    }

    public class PlaylistData
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("owner")]
        public Profile Owner { get; set; }
    }

    public class Images
    {
        [JsonProperty("items")]
        public List<CoverArt> Items { get; set; }
    }

    public class Podcasts
    {
        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }

        [JsonProperty("items")]
        public List<PodcastsItem> Items { get; set; }
    }

    public class PodcastsItem
    {
        [JsonProperty("data")]
        public PodcastData Data { get; set; }
    }

    public class PodcastData
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coverArt")]
        public CoverArt CoverArt { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("publisher")]
        public Profile Publisher { get; set; }

        [JsonProperty("mediaType")]
        public MediaType MediaType { get; set; }
    }

    public class TopResults
    {
        [JsonProperty("items")]
        public List<TopResultsItem> Items { get; set; }

        [JsonProperty("featured")]
        public List<PlaylistsItem> Featured { get; set; }
    }

    public class TopResultsItem
    {
        [JsonProperty("data")]
        public TopResultData Data { get; set; }
    }

    public class TopResultData
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("albumOfTrack")]
        public AlbumOfTrack AlbumOfTrack { get; set; }

        [JsonProperty("artists")]
        public Artists Artists { get; set; }

        [JsonProperty("contentRating")]
        public ContentRating ContentRating { get; set; }

        [JsonProperty("duration")]
        public Duration Duration { get; set; }

        [JsonProperty("playability")]
        public Playability Playability { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }

        [JsonProperty("visuals")]
        public Visuals Visuals { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("owner")]
        public Profile Owner { get; set; }
    }

    public partial class AlbumOfTrack
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coverArt")]
        public CoverArt CoverArt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("sharingInfo")]
        public SharingInfo SharingInfo { get; set; }
    }

    public partial class SharingInfo
    {
        [JsonProperty("shareUrl")]
        public Uri ShareUrl { get; set; }
    }

    public partial class Playability
    {
        [JsonProperty("playable")]
        public bool Playable { get; set; }
    }

    public partial class Tracks
    {
        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }

        [JsonProperty("items")]
        public List<TracksItem> Items { get; set; }
    }

    public partial class TracksItem
    {
        [JsonProperty("data")]
        public TrackData Data { get; set; }
    }

    public partial class TrackData
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("albumOfTrack")]
        public AlbumOfTrack AlbumOfTrack { get; set; }

        [JsonProperty("artists")]
        public Artists Artists { get; set; }

        [JsonProperty("contentRating")]
        public ContentRating ContentRating { get; set; }

        [JsonProperty("duration")]
        public Duration Duration { get; set; }

        [JsonProperty("playability")]
        public Playability Playability { get; set; }
    }

    public partial class Users
    {
        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }

        [JsonProperty("items")]
        public List<UsersItem> Items { get; set; }
    }

    public partial class UsersItem
    {
        [JsonProperty("data")]
        public UserData Data { get; set; }
    }

    public partial class UserData
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("smallImageUrl")]
        public Uri SmallImageUrl { get; set; }

        [JsonProperty("largeImageUrl")]
        public Uri LargeImageUrl { get; set; }
    }
}
