namespace Kino.Domain.Director
{
    public class Director
    {
        public static Director CreateNew(
            string directorName,
            string directorSurname
        )
        {
            return new Director(directorName, directorSurname);
        }
        public long DirectorId { get; protected set; }
        public string DirectorName { get; protected set; }
        public string DirectorSurname { get; protected set; }
        private Director() { }
        private Director(
            string directorName,
            string directorSurname
        )
        {
            DirectorName = directorName;
            DirectorSurname = directorSurname;
        }
        public void ChangeMainAttributes(
            string directorName,
            string directorSurname
        )
        {
            DirectorName = directorName;
            DirectorSurname = directorSurname;
        }
    }

}
