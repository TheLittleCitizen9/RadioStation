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
        public IEnumerable<ArtistMetadata> GetArtistsAndAlbumCount()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<Artist> GetEligibleForIsraelArtists()
        {
            throw new NotImplementedException();
        }

        public Artist GetFirstArtistWithTwoAlbums()
        {
            return _artists.Where(artist => artist.Albums.Count() == 2).ToList().First();
        }

        public IEnumerable<Artist> GetSlackerArtists()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Artist> GetYoungArtists()
        {
            return _artists.Where(artist => artist.Albums.Count() <= 2);
        }
    }
}
