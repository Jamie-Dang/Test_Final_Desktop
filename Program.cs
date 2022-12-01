using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Exercise3_4
{

    class Account
    {
        private String iD;
        private string firstName;
        private string lastName;
        private string balance;


        public String ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Balance { get; set; }

        public Account() { }
        public Account(String iD, String firstName, String lastName, String balance)
        {
            this.iD = iD;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }


        public void Input()
        {
            Console.Write("Enter ID: "); iD = Console.ReadLine();
            Console.Write("Enter first name: "); firstName = Console.ReadLine();
            Console.Write("Enter last name: "); lastName = Console.ReadLine();
            Console.Write("Enter balance: "); balance = Console.ReadLine();
        }

        public void Output()
        {
            Console.WriteLine($"ID: {iD}");
            Console.WriteLine($"First name: {firstName}");
            Console.WriteLine($"last name: {lastName}");
            Console.WriteLine($"balance: {balance}");

        }
    }
    class AccountComparer : IComparer<Account>
    {
        public int Compare(Account x, Account y)
        {
            int result = x.ID.CompareTo(y.ID);
            if (result == 0)
            {
                result = x.FirstName.CompareTo(y.FirstName);
            }
            if (result == 0)
            {
                result = x.LastName.CompareTo(y.LastName);
            }
            if (result == 0)
            {
                result = x.Balance.CompareTo(y.Balance);
            }
            return result;
        }
    }
    class AccountList
    {
        private List<Account> list = new List<Account>();

        public void Input()
        {
            do
            {
                Account ac = new Account();
                ac.Input();
                list.Add(ac);
                Console.WriteLine("Nhap nua hay khong? (y/n)");
                string st = Console.ReadLine();
                if (st.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            } while (true);
        }
/*
        public void SaveFile()
        {
            Console.WriteLine("Input file name to save: ");
            string filename = Console.ReadLine();
            try
            {
                FileStream output = new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                StreamWriter writer = new StreamWriter(output);

                foreach (Account ac in list)
                {
                    writer.WriteLine("{o}, {1}, {2}, {3}", ac.ID, ac.FirstName, ac.LastName, ac.Balance);
                }
                writer.Close();
                output.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LoadFile()
        {
            Console.Write("Input file name to load: ");
            string filename = Console.ReadLine();
            list.Clear();

            try
            {
                FileStream input = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(input);
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    string[] ds = str.Split(',');

                    Account acc = new Account(int.Parse(ds[0], ds[1], ds[2], decimal.Parse(ds[3])));
                    list.Add(acc);
                }
                input.Close();
                reader.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
*/
        public void Output()
        {
            foreach (var item in list)
            {
                item.Output();
            }
        }

        public void FindAndDelete()
        {
            Console.Write("You wanna delete which ID? : ");
            string accountID = Console.ReadLine();
            Account acFound = null;
            foreach (var item in list)
            {
                if (item.ID == accountID)
                {
                    acFound = item;
                    break;
                }
            }
            if (acFound != null)
            {
                list.Remove(acFound);
                Console.WriteLine("Deleted!!!");
            }
            else
            {
                Console.WriteLine($"Not find: {acFound}");
            }
        }


        public void SortMultiple()
        {
            list.Sort(new AccountComparer());
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            AccountList list = new AccountList();
            list.Input();
            list.Output();
        //    list.SaveFile();
        //   list.LoadFile();
            Console.WriteLine("========================");
            list.FindAndDelete();
            list.Output();
            Console.WriteLine("========================");
    /*        list.SortMultiple();
            list.Output();
            Console.WriteLine("========================");
    */
            Console.ReadLine();
        }
    }

}
