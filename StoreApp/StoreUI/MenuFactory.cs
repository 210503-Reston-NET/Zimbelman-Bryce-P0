using StoreBL;
using StoreDL;

namespace StoreUI
{
    /// <summary>
    /// Class to manufacture menus using factory
    /// </summary>
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuType) {
            switch (menuType.ToLower()) {
                case "main":
                    return new MainMenu();

                    case "customer":
                        return new CustomerMenu(new CustomerBL(new RepoFile()), new ValidationService());

                    case "manager":
                        return new ManagerMenu(new CustomerBL(new RepoFile()), new LocationBL(new RepoFile()), new ProductBL(new RepoFile()), new ValidationService());

                default:
                    return null;
            }
        }
    }
}