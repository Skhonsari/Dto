using System;

namespace Dto
{
    public class Test
    {
        public int MyProperty { get; set; }
        public int MyProperty2 { get; set; }
        public string MyProperty3 { get; set; }
        public Test(int v1, int v2, string v3)
        {
            this.MyProperty = v1;
            this.MyProperty2 = v2;
            this.MyProperty3 = v3;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var a = new DtoProvider<Test>(t => t.MyProperty2, t => t.MyProperty3);
            foreach (var item in a.createDto(new Test(1, 2, "salam")))
            {
                Console.WriteLine($"({item.Key}, {item.Value})");
            }
        }
    }
}
