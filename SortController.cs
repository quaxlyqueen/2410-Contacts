using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers;

public class SortController : Controller
{
    public static IEnumerable<Contact> QueryState { get; set; }
    private static readonly List<Contact> _contacts = new();

    public IEnumerable<Contact> MyAction()
    {
        DefaultView();
        return QueryState;
    }
    
    [HttpPost]
    public ActionResult ProductSearch(string option)
    {
        switch (option)
        {
           case "default":
               break;
           case "firstAsc":
               break;
           case "firstDesc":
               break;
           case "lastAsc":
               break;
           case "lastDesc":
               break;
        }
        
        // Generate a LINQ query based on the user's input
        IEnumerable<Contact> query = from c in _contacts
            select c;

        // Execute the query and pass the results to the view
        return View();
    }
    
        /// <summary>
    /// Default view of the database.
    /// </summary>
    public static IEnumerable<Contact> DefaultView()
    {
        QueryState =
            from c in _contacts
            select c;
        return QueryState;
    }

    /// <summary>
    /// Search the database for contacts with the provided first name. Utilizes LINQ.
    /// </summary>
    /// <param name="name"></param>
    public IEnumerable<Contact> SearchByFirstName(string name)
    {
        QueryState =
            from c in _contacts
            where c.FirstName.Contains(name)
            select c;
        return QueryState;
    }

    /// <summary>
    /// Search the database for contacts with the provided last name.
    /// </summary>
    /// <param name="name"></param>
    public IEnumerable<Contact> SearchByLastName(string name)
    {
        QueryState =
            from c in _contacts
            where c.LastName.Contains(name)
            select c;
        return QueryState;
    }

    /// <summary>
    /// Sort the database by contact first name.
    /// </summary>
    /// <param name="ascending"></param>
    public IEnumerable<Contact> SortByFirstName(bool ascending)
    {
        if (ascending)
            QueryState =
                (from c in _contacts
                    select c).OrderBy(contact => contact.FirstName);

        else
            QueryState =
                (from c in _contacts
                    select c).OrderByDescending(contact => contact.FirstName);

        return QueryState;
    }

    /// <summary>
    /// Sort the database by contact last name.
    /// </summary>
    /// <param name="ascending"></param>
    public IEnumerable<Contact> SortByLastName(bool ascending)
    {
        if (ascending)
            QueryState =
                (from c in _contacts
                    select c).OrderBy(contact => contact.LastName);

        else
            QueryState =
                (from c in _contacts
                    select c).OrderByDescending(contact => contact.LastName);

        return QueryState;
    }

    /// <summary>
    /// Sort the database by contact birthdate.
    /// </summary>
    /// <param name="ascending"></param>
    public IEnumerable<Contact> SortByBirthdate(bool ascending)
    {
        if (ascending)
            QueryState =
                (from c in _contacts
                    select c).OrderBy(contact => contact.Bday);

        else
            QueryState =
                (from c in _contacts
                    select c).OrderByDescending(contact => contact.Bday);

        return QueryState;
    }

    /// <summary>
    /// Sort the database by contact category.
    /// <param name="ascending"></param>
    public IEnumerable<Contact> SortByCategory(bool ascending)
    {
        if (ascending)
            QueryState =
                (from c in _contacts
                    select c).OrderBy(contact => contact.Type);

        else
            QueryState =
                (from c in _contacts
                    select c).OrderByDescending(contact => contact.Type);

        return QueryState;
    }

    /// <summary>
    /// Remove a contact from the database.
    /// </summary>
    /// <param name="cToDelete">Contacts object to find and remove.</param>
    /// <exception cref="ArgumentException">Thrown if the contact is not stored in the database.</exception>
    public IEnumerable<Contact> Delete(Contact cToDelete)
    {
        if (!_contacts.Remove(cToDelete))
            throw new ArgumentException("Contacts does not exist.");

        return QueryState;
    }
}