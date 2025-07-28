
using OOPAssignment3.Classes;
using OOPAssignment3.Interfaces;

namespace OOPAssignment3
{
    internal class Program
    {
        [Flags]
        public enum UserRole
        {
            User = 1,
            Admin = 2,
            Manager = 4,
            TeamLeader = 8
        }

        static void Main(string[] args)
        {
            #region 1. What is the primary purpose of an interface in C#?
            // b) To define a blueprint for a class
            #endregion

            #region 2. Which of the following is NOT a valid access modifier for interface members in C#?
            // a) private
            #endregion

            #region 3. Can an interface contain fields in C#?
            // c) Only if they are static
            #endregion

            #region 4. In C#, can an interface inherit from another interface?
            // b) Yes, interfaces can inherit from multiple interfaces
            #endregion

            #region 5. Which keyword is used to implement an interface in a class in C#?
            // none of gthe answers is valid because only : is used
            #endregion

            #region 6. Can an interface contain static methods in C#?
            // a) Yes
            #endregion

            #region 7. In C#, can an interface have explicit access modifiers for its members?
            // b) No, all members are implicitly public
            #endregion

            #region 8. What is the purpose of an explicit interface implementation in C#?
            // b) To provide a clear separation between interface and class members
            #endregion

            #region 9. In C#, can an interface have a constructor?
            // b) No, interfaces cannot have constructors
            #endregion

            #region 10. How can a C# class implement multiple interfaces?
            // c) By separating interface names with commas
            #endregion

            //////////////////////////////
            /// Part 2
            
            #region Question 01:
            Rectangle rect = new Rectangle(5, 6);
            rect.DisplayShapeInfo();

            Circle circle = new Circle(3.2);
            circle.DisplayShapeInfo();
            #endregion


            #region Question 02:
            IAuthenticationService authService = new BasicAuthenticationService();


            Console.WriteLine("Enter username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();

            if (!authService.AuthenticateUser(username, password))
            {
                Console.WriteLine("Authentication failed");
                return;
            }

            Console.WriteLine("Authentication successful");

            Console.WriteLine("Enter role (User, Manager, Administrator)");
            string role = Console.ReadLine();

            if (!Enum.TryParse(role, out UserRole inputRole))
            {
                Console.WriteLine("inavlid role");
                return;
            }

            if (authService.AuthorizeUser(username, inputRole))
            {
                Console.WriteLine($"{username} is authorized for role: {inputRole}");
            }
            else
            {
                Console.WriteLine($"{username} is not authorized for role: {inputRole}");
            }
            #endregion


            #region Question 03:
            INotificationService email = new EmailNotificationService();
            INotificationService sms = new SmsNotificationService();
            INotificationService notif = new PushNotificationService();

            email.SendNotification("Maya", "Dear maya,\n hope this email find you well.");
            sms.SendNotification("Hana", "Hi, how are you!");
            notif.SendNotification("Mai", "New message recieved");

            #endregion
        }
        


    }
}

