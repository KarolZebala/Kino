namespace Kino.Domain.Movie
{
    public class MovieVersion 
    {
        public static MovieVersion CreateNew(int duration,
            string soundVersion,
            string imageVersion,
            string languageVerion,
            bool hasSubstitles
        )
        {
            return new MovieVersion(
                duration: duration,
                soundVersion: soundVersion,
                imageVersion: imageVersion,
                languageVerion: languageVerion,
                hasSubstitles: hasSubstitles
            );
        }


        public long MovieVersionId { get; protected set; }
        public int Duration { get; protected set; }
        public string SoundVersion { get; protected set; }
        public string ImageVersion { get; protected set; }
        public string LanguageVerion { get; protected set; }
        public bool HasSubstitles { get; protected set; }
        public long MovieId { get; protected set; }
        private MovieVersion()
        {

        }
        private MovieVersion(
            int duration,
            string soundVersion,
            string imageVersion,
            string languageVerion,
            bool hasSubstitles
        )
        {
            Duration = duration;
            SoundVersion = soundVersion;
            ImageVersion = imageVersion;
            LanguageVerion = languageVerion;
            HasSubstitles = hasSubstitles;
        }

        public void ChangeMainAttributes(
            int duration,
            string soundVersion,
            string imageVersion,
            string languageVerion,
            bool hasSubstitles
        )
        {
            Duration = duration;
            SoundVersion = soundVersion;
            ImageVersion = imageVersion;
            LanguageVerion = languageVerion;
            HasSubstitles = hasSubstitles;
        }
    }

}
