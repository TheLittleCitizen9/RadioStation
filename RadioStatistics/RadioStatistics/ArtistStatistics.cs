using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RadioStatistics.Abstract;

namespace RadioStatistics
{
    public class ArtistStatistics : IArtistStatistics
    {
        private IEnumerable<Artist> _artists;
        public ArtistStatistics(IEnumerable<Artist> artists)
        {
            _artists = artists;
        }

        public IEnumerable<Artist> GetArtistsOrderdByName()
        {
            return _artists.OrderBy(artist => artist.Name);
        }

        public Artist GetArtistWithMostAlbums()
        {
            return _artists.OrderByDescending(artist => artist.Albums.Count()).First();
        }

        public IEnumerable<Artist> GetCatchyNamedArtists()
        {
            return _artists.Where(artist => artist.Name.Length < 7);
        }

        public IEnumerable<Artist> GetDiggingArtists()
        {
            return _artists.Where(a => a.Albums.Where(a => a.Tracks.Where(t => t.Duration > TimeSpan.FromHours(1)).Any()).Any());
        }

        public IEnumerable<Artist> GetEligibleForIsraelArtists()
        {
            return _artists.Where(a => a.Albums.Sum(a => a.Tracks.Sum(t => t.Duration.TotalSeconds)) > 7200);
        }

        public Artist GetFirstArtistWithTwoAlbums()
        {
            return _artists.Where(artist => artist.Albums.Count() == 2).ToList().First();
        }

        public IEnumerable<Artist> GetSlackerArtists()
        {
            return _artists.Where(a => a.Albums.Where(a => a.Tracks.Where(t => t.Duration.TotalSeconds < 60).Count() >= 2).Any());
        }

        public IEnumerable<Artist> GetYoungArtists()
        {
            return _artists.Where(artist => artist.Albums.Count() <= 2);
        }

        IEnumerable<ArtistMetadata> IArtistStatistics.GetArtistsAndAlbumCount()
        {
            return _artists.ToList().Select(a => new ArtistMetadata() { AlbumCount = a.Albums.Count(), Name = a.Name });
        }
    }
}
