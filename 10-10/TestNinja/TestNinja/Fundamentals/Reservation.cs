namespace TestNinja.Fundamentals
{
    public class Reservation
    {
        public User MadeBy { get; set; }

        public bool CanBeCancelledBy(User user)
        {
            // odwołać może admin
            if(user.IsAdmin)
                return true;

            // albo właściciel
            if(user == MadeBy)
                return true;

            // nikt inny nie może
            else
                return false;

        }

    }

    public class User
    {
        public bool IsAdmin { get; set; }
    }
}