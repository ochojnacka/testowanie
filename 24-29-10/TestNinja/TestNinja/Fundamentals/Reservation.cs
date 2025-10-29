namespace TestNinja.Fundamentals
{
    public class Reservation
    {
        public User MadeBy { get; set; }

        public bool CanBeCancelledBy(User user)
        {
            //odwołać może admin albo właściciel
            //inne osoby nie mogą odwołać rezerwacji
            return (user.IsAdmin || MadeBy == user);
        }        
    }

    public class User
    {
        public bool IsAdmin { get; set; }
    }
}