using System;
using System.Collections.Generic;


namespace Assignment2
{
    // class Member 
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthPlace { get; set; }
        public int Age { get; set; }
        public bool IsGraduated { get; set; }

        //Constructor
        public Member(string fn, string ln, string gd, int dob, string p, string bp, bool ig)
        {
            FirstName = fn;
            LastName = ln;
            Gender = gd;
            DateOfBirth = dob;
            PhoneNumber = p;
            BirthPlace = bp;
            Age = 2022 - dob;
            IsGraduated = ig;
        }
        
        public override string ToString()
        {
            return string.Format("Fullname: {0} {1}, Gender: {2}, DoB: {3}, Phone: {4}, BirthPlace: {5}, Age: {6}, Graduated: {7}", FirstName, LastName, Gender, DateOfBirth, PhoneNumber, BirthPlace, Age, (IsGraduated == false) ? "No" : "Yes");
        }
        
    }

    class Program
    {
        static void ShowMember<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + list[i]);
            }
        }

        static List<Member> MaleMembers(List<Member> list){
            var malemembers = from member in list
                            where member.Gender == "Male" select member;
            return malemembers.ToList();
        }

        static Member OldestMember(List<Member> list){
            var mem = from member in list
                        orderby member.Age descending
                        select member;
            return mem.ToList()[0];
        }

        static List<string> FullNameList(List<Member> list){
            var fullname = from member in list
                            select string.Join(" ", member.FirstName, member.LastName);
            return fullname.ToList();
        }

        static List<List<Member>> List3(List<Member> list){
            var under2000 = from member in list
                            where (member.DateOfBirth < 2000)
                            select member;
            var is2000 = from member in list
                            where (member.DateOfBirth == 2000)
                            select member;
            var over2000 = from member in list
                            where (member.DateOfBirth > 2000)
                            select member;

            List<List<Member>> list3 = new List<List<Member>>{under2000.ToList(), is2000.ToList(), over2000.ToList()};
            return list3;
        }

        static Member BornInHanoi(List<Member> list){
            var mem = from member in list
                        where (member.BirthPlace == "Ha noi")
                        select member;
            return mem.ToList()[0];
        }

        //Main
        static void Main(string[] args)
        {
            List<Member> cl = new List<Member>();
            


            cl.Add(new Member("Nguyen", "Nam Phuong", "Male", 2001, "0943746666", "Ha noi", false));
            cl.Add(new Member("Do", "Hong Son", "Male", 2000, "0975378309", "Nam dinh", false));
            cl.Add(new Member("Nguyen", "Duc Huy", "Male", 1996, "0925206686", "Ha noi", true));
            cl.Add(new Member("Phuong", "Viet Hoang", "Male", 1999, "0702028599", "Nam dinh", false));
            cl.Add(new Member("Lai", "Quoc Long", "Male", 1997, "0354505588", "Bac ninh", true));
            cl.Add(new Member("Tran", "Chi Thanh", "Male", 2000, "0376959875", "Ha noi", false));
            cl.Add(new Member("Vu", "Quang Hiep", "Male", 2000, "0964910360", "Nghe an", false));
            cl.Add(new Member("Pham", "Duc Loc", "Male", 1999, "0343428821", "Bac ninh", false));
            cl.Add(new Member("Do", "Trung Anh", "Male", 1996, "0422061033", "Hai phong", true));
            cl.Add(new Member("Trinh", "Hong Nhung", "Female", 1999, "0123456789", "Thanh hoa", true));
            cl.Add(new Member("Dao", "Quy Vuong", "Male", 2000, "0335878777", "Ha noi", false));
            cl.Add(new Member("Bui", "Chi Huong", "Male", 2000, "0338559513", "Nghe an", false));
            cl.Add(new Member("Pham", "Thanh Long", "Male", 2000, "0944531628", "Ninh binh", false));
            cl.Add(new Member("Pham", "Duc Tien", "Male", 1998, "0963164813", "Ninh binh", false));
            cl.Add(new Member("Nguyen", "Quang Huy", "Male", 1992, "0842140392", "Ha noi", true));
            cl.Add(new Member("Pham", "Duc Tien", "Male", 1998, "0963164813", "Ninh binh", false));

            Console.WriteLine("1.-----List of male member: ");
            ShowMember(MaleMembers(cl));
        

            Console.WriteLine("2.-----Oldest member in class: ");
            Console.WriteLine(OldestMember(cl));

            Console.WriteLine("3.-----New list with fullname only: ");
            ShowMember(FullNameList(cl));

            Console.WriteLine("4.-----New 3 list: ");
            Console.WriteLine("Birth year less than 2000: ");
            ShowMember(List3(cl)[0]);
            Console.WriteLine("Birth year is 2000: ");
            ShowMember(List3(cl)[1]);
            Console.WriteLine("Birth year greater than 2000: ");
            ShowMember(List3(cl)[2]);

            Console.WriteLine("5.-----First person who was born in Hanoi: ");
            Console.WriteLine(BornInHanoi(cl).ToString());
            Console.ReadKey();

        }
    }
}

