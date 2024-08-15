using System.Security.Cryptography.X509Certificates;
using Dumpify;

public class Student{
    public int rollno;
    public int marks;
    public string subject;
    public Student(int rollno, int marks, string subject){
        this.rollno=rollno;
        this.marks=marks;
        this.subject=subject;
    }
}
public class Program{

    static List<Student> students=new List<Student>();
   
    static Action<string>print=x=>Console.WriteLine(x);
    static List<int> coll=[1,42,12,56,37,88,22,99];

    public static void LearnFiltering(){
        //Filter numbers greater than 50
        var filtered=coll.Where(x=>x>50);
        print($"Filtered numbers: {string.Join(", ", filtered)}");

        //Filter students with marks greater than 50;
        students.Where(x=>x.marks>50).Select(x=>$"RollNo: {x.rollno} Marks: {x.marks} Subjects: {x.subject}").Dump();

    }

    public static  void LearnSkip(){
        print("Using Skip Method to skip first 2 elements ");
        coll.Skip(2).Dump();
         print("Using Take Method to Take first 5 elements ");
        coll.Take(5).Dump();
        print("Using SkipLast Method to skip last 2 elements ");
        coll.SkipLast(2).Dump();
        print("Using TakeLast Method to Take last 5 elements ");
        coll.TakeLast(5).Dump();
        print("Using SkipWhile Method to stop at particular condition : 'It will stop when the condition matches'");
        coll.SkipWhile(x=>x<50).Dump();
        print("Using TakeWhile Method to take elements until a  particular position : 'It will stop when the condition matches'");
        coll.TakeWhile(x=>x<50).Dump();
    }
    public static void LearnSelect(){
            //Select is used to just manipulate the date which is not in place . Note : Its not like where constion 
            print("Note : Its not used for filtering Its act as same select in sql  'select sal*10 from emp ' here it take sal attribute and apply sal*10 ");
            coll.Select(x=>$"Square of {x} is {x*x}").Dump();
            print("If we deals with objects ");
            students.Select(x=>$"Student Roll: {x.rollno} Marks :{x.marks} subject: {x.subject}").Dump();
            //Select Many is used if we deals with array of arry like  (Jagged array ) 🤯;
            List<List<int>> jaggedList=[[1,2,4,5,6,7],[1,3,4,6,2,1]];
            jaggedList.Select(x=>/*here x is   jaggedList[0]=[1,2,4,5,6,7]*/x.Select(x/*Here x is inside JaggedList[0]*/=>$"Square of {x} is {x*x}")  ).Dump();
    }
    public static void LearnQuantifiers(){
        //Any Method
        print("Using Any Method : 'It returns true atleast one element statisfy the condition '");
        coll.Any(x=>x>70).Dump();
        //All Method
        print("Using All Method : 'It returns true All  elements statisfy the condition");
        coll.All(x=>x>0).Dump();
        //Contains Method 
        print("Contains method is used to check wheather particular element is present in collection or not  ");
        coll.Contains(37).Dump();
        //Using Contains with Objects 
        print(" Note'For Objects it Doesnot works same as primitive datatypes");
        //It return false even though object valeus are matched ;
        students.Contains(new Student(56,81,"Maths")).Dump();
        Student s=students[2];
        //It returns true if we deals with same object address;
        print("Contains with same object address");
        students.Contains(s).Dump();
    }

    public static void LearnAppendPrepend(){
        print("List before applying apped Method ");
        coll.Dump();
        print("If we use Append method , it will add element as end of list \n After applying append function  ");
        coll.Append(100).Dump();
         print("List before applying Prepend Method ");
        coll.Dump();
        print("If we use Prepend method , it will add element as begin of list \n After applying Prepend function  ");
        coll.Prepend(-1).Dump();

    }

public static void LearnAggregation(){

        //Count Method 
        print("Count Method is used to Display No.of Elements in the collection \n ");
        print($"No Of elements in Students List : {students.Count()} \n No.Of Elements in coll List : {coll.Count()} \n\n");
        
        //Max 
        print($"Max in primitive data type return an value which is maximum \n Max value in coll is :{coll.Max()}\n");
        //MaxBy
        print($"MaxBy is used to find the object on max value on particular Property like it may be roll, marks  ");
       Student s=students.MaxBy(x=>x.marks);
       print($"Max Marks by student roll   :{s.rollno} with marks : {s.marks}\n");
       //Min 
        print($"Min in primitive data type return an value which is Minimum \n Min value in coll is :{coll.Min()}\n");
        //MinBy
        print($"MinBy is used to find the object on min value on particular Property like it may be roll, marks  ");
       Student s1=students.MinBy(x=>x.marks);
       print($"Min Marks by student roll   :{s1.rollno} with marks : {s1.marks}\n");

    //Sum 
    print($"Sum of Elements in collection {coll.Sum()}\n ");
    print($"We can apply sum for objects also \n Total Marks :  {students.Sum(x=>x.marks)}\n ");
    //Average
    print($"Average in Collection {coll.Average()}\n");
    //Aggregate 
    print($"Aggregrate is to take 2 values from a list-> compute operation -> store the results futhere\nAggregate of collection : {coll.Aggregate((x,y)=>(x+y))}");

}
public static void LearnConvertions(){
    print("\nTo convert one type of collection to another");
    print("Most Operation that we perform on an collectoin will return IEnumerable so we can convert to our own type like list, dict..etc");
    //To Array 
    coll.ToArray().Dump();
    //ToDictionary
    coll.ToDictionary(x=>x,x=>x*x).Dump();
//ToHashset  : it removes duplicates
    coll.ToHashSet().Dump();

}
public static void LearnDistinct(){
    print("Distinct Method will return Disctinct elements in collection");
    coll.Distinct().Dump();
    print("Applying DistinctBy on property roll no");
    students.DistinctBy(x=>x.rollno).Select(x=>$"{x.rollno} {x.marks} {x.subject} ").Dump();
}
public static void LearnSetOperations(){
    List<int> coll1=[1,2,4,5,3,6];
    List<int>coll2=[5,7,8,2,4,0];
    //Union 
    print("Union Col1 and Col2 \t'Note :No repeation of intersection elements '");
    coll1.Union(coll2).Dump();
    //Intersection
    print("Instersection of col1 and col2 ");
    coll1.Intersect(coll2).Dump();
    //Except A-B;
    print("Except is A-B  i,e contains elements in A that not in B");
    coll1.Except(coll2).Dump();
    //Dealing With Objects 
    List<Student> students1=new List<Student>();
    List<Student>students2=new List<Student>();
        students1.Add(new Student(56,81,"Maths"));
        students1.Add(new Student(22,42,"Science"));
        students2.Add(new Student(99,92,"English"));
        students2.Add(new Student(56,12,"Social Studies"));
//UnionBy 
print("Using Union By ");
    students1.UnionBy(students2,x=>x.rollno).Select(x=>$"{x.rollno} {x.marks} {x.subject}").Dump();
    //Intersection By 
print("\nUsing IntersectBy ");
    students1.IntersectBy(students2.Select(x=>x.rollno),x=>x.rollno).Select(x=>$"{x.rollno} {x.marks} {x.subject}").Dump();
    //Except By
    print("\n Using ExceptBy ");
    students1.ExceptBy(students2.Select(x=>x.rollno),x=>x.rollno).Select(x=>$"{x.rollno} {x.marks} {x.subject}").Dump();
}

public static void LearnJoining_Grouping(){
    //Zip 
    print("Zip Method is used to map col1 -> col2 ,size of output will be minsizeof(col1,col2) ");
    List<int>roll=[1,2,3,4,5];
    List<string>name=["Sai","Teja","Kotla","Tanish","Bharath"];
    roll.Zip(name).Select(x=>$"Roll no :{x.First}\t Name: {x.Second}").Dump();

    //Concat
    print("Concat List roll  with List coll");
    roll.Concat(coll).Dump();

    //Grouping the student with same roll Number from  static students List ;
    print("Structure of Group By ");
    var GroupByRoll=students.GroupBy(x=>x.rollno).Dump();
    print("Traversing the groups ");
    foreach(var c in GroupByRoll){
        print($"Roll No : {c.Key} {/* Here we pointing each grouping object and taking key as roll no because we done grouping with rollno */" "} ");
        foreach(var i in c){
            print($"Subject  {i.subject} Marks {i.marks}");
        }
    }
    //Converting grouping object to Dictionary;

    print("\nConverting the grouping object to dictionary ");
    print("Structure of Dictionary ");
    var dict =GroupByRoll.ToDictionary(x=>x.Key,x=>x.ToList()).Dump();
    //Here key of the Dictionary is RollNo because we done groupby with rollno and Values are Listof students because we make explicit to List in above line 

    print("\nPrinting The Dictionary Items using foreach \n ");
    foreach(var dictindex in dict){
        print($"\nRoll No : {dictindex.Key}");
        foreach(var i in dictindex.Value){
            print($"Subjects {i.subject} Marks {i.marks}");
        }
    }

}
public static void LearnSorting(){
    //Lets Sort Students list based on their marks ascending ;
   print("\nLets Sort Students list based on their marks ascending");
    students.OrderBy(x=>x.marks).ToList().Select(x=>$"Roll no {x.rollno} Marks {x.marks} Subjects {x.subject}").Dump();
    //Lets Sort Students list based on their marks Descending ;
    print("\nLets Sort Students list based on their marks Descending");
    students.OrderByDescending(x=>x.marks).ToList().Select(x=>$"Roll no {x.rollno} Marks {x.marks} Subjects {x.subject}").Dump();
    //If We there is a tie then we want to sort according to other property use ThenBy method;
    print("\nApplying sorting ascending based on Marks if there 2 same values sort based on ascending order of roll nos ");
    students.OrderBy(x=>x.marks).ThenBy(x=>x.rollno).Select(x=>$"Roll no {x.rollno} Marks {x.marks} Subjects {x.subject}").Dump();
      //If We there is a tie then we want to sort according to other property Descending use ThenByDescending method;
     print("\nApplying sorting ascending based on Marks if there 2 same values sort based on Descending order of roll nos ");
    students.OrderBy(x=>x.marks).ThenByDescending(x=>x.rollno).Select(x=>$"Roll no {x.rollno} Marks {x.marks} Subjects {x.subject}").Dump();

}
public static void LearnReverse(){
    print("It is used to reverse the elements in the Collections \n Elements in list coll before appling Reverse Method ");
    coll.Dump();
    print("Elements afeter applying Reverse Method");
    coll.Reverse();
    coll.Dump();

}

    public static void Main(string[] args)
    {
         students.Add(new Student(56,81,"Maths"));
         students.Add(new Student(22,42,"Science"));
         students.Add(new Student(99,92,"English"));
         students.Add(new Student(56,12,"Social Studies"));
//Uncomment the following line if you want to learn that paticular Linq Method ;
        LearnFiltering();
        LearnSkip();
        LearnSelect();
        LearnQuantifiers();
        LearnAppendPrepend();
        LearnAggregation();
        LearnConvertions();
        LearnDistinct();
        LearnSetOperations();
        LearnJoining_Grouping();
        LearnSorting();
        LearnReverse();
    }
}

