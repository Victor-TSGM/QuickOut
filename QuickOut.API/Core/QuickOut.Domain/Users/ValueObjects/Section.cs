using QuickOut.Library;

namespace QuickOut.Domain.Users
{
    public class Section
    {
        public Guid Id { get; private set; }
        public User User { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Token { get; private set; }

        protected Section()
        {

        }

        public static Result<Section> StartSection(
                User user,
                DateTime startDate,
                string token
            )
        {
            Section entity = new Section()
            {
                Id = Guid.NewGuid(),
                User = user,
                StartDate = startDate,
                Token = token
            };

            return Result<Section>.Success(entity);
        }

        public void CloseSection()
        {
            this.EndDate = DateTime.UtcNow;
        }
    }
}
