using System;

class Contact
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public Contact(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }

    public override string ToString()
    {
        return $"{Name}: {PhoneNumber}";
    }
}

class TreeNode
{
    public Contact Data;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(Contact data)
    {
        Data = data;
        Left = Right = null;
    }
}

class Phonebook
{
    private TreeNode root;

    public Phonebook()
    {
        root = null;
    }

    public void AddContact(Contact contact)
    {
        root = InsertRecursive(root, contact);
    }

    private TreeNode InsertRecursive(TreeNode root, Contact contact)
    {
        if (root == null)
        {
            return new TreeNode(contact);
        }

        int comparisonResult = string.Compare(contact.Name, root.Data.Name, StringComparison.OrdinalIgnoreCase);

        if (comparisonResult < 0)
        {
            root.Left = InsertRecursive(root.Left, contact);
        }
        else
        {
            root.Right = InsertRecursive(root.Right, contact);
        }

        return root;
    }

    public Contact SearchByName(string name)
    {
        return SearchByNameRecursive(root, name);
    }

    private Contact SearchByNameRecursive(TreeNode root, string name)
    {
        if (root == null)
        {
            return null;
        }

        int comparisonResult = string.Compare(name, root.Data.Name, StringComparison.OrdinalIgnoreCase);

        if (comparisonResult == 0)
        {
            return root.Data;
        }

        if (comparisonResult < 0)
        {
            return SearchByNameRecursive(root.Left, name);
        }

        return SearchByNameRecursive(root.Right, name);
    }

    public void DisplayInOrder()
    {
        DisplayInOrderRecursive(root);
    }

    private void DisplayInOrderRecursive(TreeNode root)
    {
        if (root != null)
        {
            DisplayInOrderRecursive(root.Left);
            Console.WriteLine(root.Data);
            DisplayInOrderRecursive(root.Right);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Phonebook phonebook = new Phonebook();
        phonebook.AddContact(new Contact("Karen", "374-55-822-721"));
        phonebook.AddContact(new Contact("Sargis", "374-77-822-737"));
        phonebook.AddContact(new Contact("Gevor", "374-98-822-321"));
        phonebook.AddContact(new Contact("Harut", "374-55-822-702"));
        phonebook.AddContact(new Contact("Arayik", "374-55-822-602")); 
        phonebook.AddContact(new Contact("Jon", "374-55-822-601"));
        phonebook.AddContact(new Contact("Guren", "374-55-822-422"));
        phonebook.AddContact(new Contact("Vahe", "374-55-822-002"));
        phonebook.AddContact(new Contact("Kolya", "374-55-822-777"));
        phonebook.AddContact(new Contact("Armen", "374-55-822-765"));
        phonebook.AddContact(new Contact("Aram", "374-55-822-999"));

        Console.WriteLine("Searching for 'Armen':");
        Contact person = phonebook.SearchByName("Armen");
        if (person != null)
        {
            Console.WriteLine("Contact found: " + person);
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }

        Console.WriteLine("\nPhonebook (Alphabetical Order):");
        phonebook.DisplayInOrder();
    }
}