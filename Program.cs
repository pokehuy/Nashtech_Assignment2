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
        public Member(string firstname, string lastname, string gender, int dateofbirth, string phone, string birthplace, bool isgraduated)
        {
            FirstName = firstname;
            LastName = lastname;
            Gender = gender;
            DateOfBirth = dateofbirth;
            PhoneNumber = phone;
            BirthPlace = birthplace;
            Age = 2022 - dateofbirth;
            IsGraduated = isgraduated;
        }
        
        public override string ToString()
        {
            return string.Format("Fullname: {0} {1}, Gender: {2}, DoB: {3}, Phone: {4}, BirthPlace: {5}, Age: {6}, Graduated: {7}", FirstName, LastName, Gender, DateOfBirth, PhoneNumber, BirthPlace, Age, (IsGraduated == false) ? "No" : "Yes");
        }
        
    }

    public interface IProgram{
        List<Member> GetMaleMembers(List<Member> listMember);
        Member GetOldestMember(List<Member> listMember);
        List<string> GetFullNameList(List<Member> listMember);
        List<List<Member>> List3(List<Member> listMember);
        Member GetHanoiMember(List<Member> listMember);
    }
    class Program : IProgram
    {
        public void ShowMember<T>(List<T> listMember)
        {
            for (int i = 0; i < listMember.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + listMember[i]);
            }
        }

        public List<Member> GetMaleMembers(List<Member> listMember){
            var maleMembers = from member in listMember where member.Gender == "Male" select member;
            return maleMembers.ToList();
        }

        public Member GetOldestMember(List<Member> listMember){
            var oldestMember = from member in listMember orderby member.Age descending select member;
            return oldestMember.FirstOrDefault();
        }

        public List<string> GetFullNameList(List<Member> listMember){
            var fullname = from member in listMember select string.Join(" ", member.FirstName, member.LastName);
            return fullname.ToList();
        }

        public List<List<Member>> List3(List<Member> listMember){
            var under2000 = from member in listMember where (member.DateOfBirth < 2000) select member;
            var is2000 = from member in listMember where (member.DateOfBirth == 2000) select member;
            var over2000 = from member in listMember where (member.DateOfBirth > 2000) select member;

            List<List<Member>> list3 = new List<List<Member>>{under2000.ToList(), is2000.ToList(), over2000.ToList()};
            return list3;
        }

        public Member GetHanoiMember(List<Member> listMember){
            var mem = from member in listMember where (member.BirthPlace == "Ha noi") select member;
            return mem.FirstOrDefault();
        }

        //Main
        static void Main(string[] args)
        {
            List<Member> listMembers = new List<Member>();
            Program prog = new Program();

            listMembers.Add(new Member("Nguyen", "Nam Phuong", "Male", 2001, "0943746666", "Ha noi", false));
            listMembers.Add(new Member("Do", "Hong Son", "Male", 2000, "0975378309", "Nam dinh", false));
            listMembers.Add(new Member("Nguyen", "Duc Huy", "Male", 1996, "0925206686", "Ha noi", true));
            listMembers.Add(new Member("Phuong", "Viet Hoang", "Male", 1999, "0702028599", "Nam dinh", false));
            listMembers.Add(new Member("Lai", "Quoc Long", "Male", 1997, "0354505588", "Bac ninh", true));
            listMembers.Add(new Member("Tran", "Chi Thanh", "Male", 2000, "0376959875", "Ha noi", false));
            listMembers.Add(new Member("Vu", "Quang Hiep", "Male", 2000, "0964910360", "Nghe an", false));
            listMembers.Add(new Member("Pham", "Duc Loc", "Male", 1999, "0343428821", "Bac ninh", false));
            listMembers.Add(new Member("Do", "Trung Anh", "Male", 1996, "0422061033", "Hai phong", true));
            listMembers.Add(new Member("Trinh", "Hong Nhung", "Female", 1999, "0123456789", "Thanh hoa", true));
            listMembers.Add(new Member("Dao", "Quy Vuong", "Male", 2000, "0335878777", "Ha noi", false));
            listMembers.Add(new Member("Bui", "Chi Huong", "Male", 2000, "0338559513", "Nghe an", false));
            listMembers.Add(new Member("Pham", "Thanh Long", "Male", 2000, "0944531628", "Ninh binh", false));
            listMembers.Add(new Member("Pham", "Duc Tien", "Male", 1998, "0963164813", "Ninh binh", false));
            listMembers.Add(new Member("Nguyen", "Quang Huy", "Male", 1992, "0842140392", "Ha noi", true));
            listMembers.Add(new Member("Pham", "Duc Tien", "Male", 1998, "0963164813", "Ninh binh", false));

            Console.WriteLine("1.-----List of male member: ");
            var listMale = prog.GetMaleMembers(listMembers);
            prog.ShowMember(listMale);
        

            Console.WriteLine("2.-----Oldest member in class: ");
            Console.WriteLine(prog.GetOldestMember(listMembers));

            Console.WriteLine("3.-----New list with fullname only: ");
            var listFullName = prog.GetFullNameList(listMembers);
            prog.ShowMember(listFullName);

            Console.WriteLine("4.-----New 3 list: ");
            Console.WriteLine("Birth year less than 2000: ");
            var listUnder2000 = prog.List3(listMembers)[0];
            prog.ShowMember(listUnder2000);
            Console.WriteLine("Birth year is 2000: ");
            var list2000 = prog.List3(listMembers)[1];
            prog.ShowMember(list2000);
            Console.WriteLine("Birth year greater than 2000: ");
            var listOver2000 = prog.List3(listMembers)[2];
            prog.ShowMember(listOver2000);

            Console.WriteLine("5.-----First person who was born in Hanoi: ");
            var hanoiMember = prog.GetHanoiMember(listMembers).ToString();
            Console.WriteLine(hanoiMember);
            Console.ReadKey();

        }
    }
}

