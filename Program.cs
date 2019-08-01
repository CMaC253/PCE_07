using System;

namespace PCE_StarterProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // BarChart_Demonstration bcd = new BarChart_Demonstration();
            // bcd.RunExercise();

            // TVStorage_Demonstration tvsd_d = new TVStorage_Demonstration();
            // tvsd_d.RunExercise();

            Basic_Inheritance bi = new Basic_Inheritance();
            bi.RunExercise();

            Constructors_Calling_One_From_Another ccofa = new Constructors_Calling_One_From_Another();
            ccofa.RunExercise();

            Calling_Methods_In_Base_Class cmibc = new Calling_Methods_In_Base_Class();
            cmibc.RunExercise();

            Inheritance_Constructors ic = new Inheritance_Constructors();
            ic.RunExercise();

            //Explain_Basic_Polymorphism ebp = new Explain_Basic_Polymorphism();
            //ebp.RunExercise();

            // Create_Basic_Polymorphic_Method cbpm = new Create_Basic_Polymorphic_Method();
            // cbpm.RunExercise();

            Polymorphism_And_Arrays paa = new Polymorphism_And_Arrays();
            paa.RunExercise();

            Overriding_ToString ot = new Overriding_ToString();
            ot.RunExercise();

            // ToString_And_Arrays taa = new ToString_And_Arrays();
            // taa.RunExercise();
        }

        /////////////////////////////////////////////////////////////////////////////////

        public class BarChart
        {
            int[] m_numbers;

            public BarChart()
            {
                m_numbers = new int[5];
            }

            public int GetSize()
            {
                return m_numbers.Length;
            }

            public void SetValue(int newVal, int idx)
            {
                if (idx >= 0 && idx < m_numbers.Length)
                    m_numbers[idx] = newVal;

                // Interesting point: note the silent failure
                // if idx is out of range
            }

            public int GetValue(int idx)
            {
                if (idx >= 0 && idx < m_numbers.Length)
                    return m_numbers[idx];

                // Is this a good value to return here?
                return 0;
            }

            public double GetAverage()
            {
                // TODO: Implement this!!
                return Double.MinValue;
            }

            public void PrintBarChart()
            {
                // TODO: Implement this!!
            }
        }
        public class BarChart_Demonstration
        {
            public void RunExercise()
            {
                BarChart h1 = new BarChart();
                BarChart h2 = new BarChart();

                for (int i = 0; i < 5; i++)
                {
                    h1.SetValue((i + 1) * 2, i);
                    h2.SetValue(10 - i, i);
                }


                Console.WriteLine("Data set 1 (Version 1): Avg: {0:0.00}", h1.GetAverage());
                h1.PrintBarChart();
                Console.WriteLine();

                // What if the first two values were different?
                h1.SetValue(5, 0);
                h1.SetValue(7, 1);

                Console.WriteLine("Data set 1 (Version 2): Avg: {0:0.00}", h1.GetAverage());
                h1.PrintBarChart();
                Console.WriteLine();

                // Wait, hold on - I got those backwards :)
                h1.SetValue(7, 0);
                h1.SetValue(5, 1);

                Console.WriteLine("Data set 1 (Version 3): Avg: {0:0.00}", h1.GetAverage());
                h1.PrintBarChart();
                Console.WriteLine();

                // I just got some new data - let me adjust the first value:
                h1.SetValue(9, 0);

                Console.WriteLine("Data set 1 (Version 4): Avg: {0:0.00}", h1.GetAverage());
                h1.PrintBarChart();
                Console.WriteLine();

                // How do the two data sets compare?
                Console.WriteLine("Data set 1 (Version 4): Avg: {0:0.00}", h1.GetAverage());
                Console.WriteLine("Data set 2 (Version 1): Avg: {0:0.00}", h2.GetAverage());

                Console.WriteLine("\nData set 1:");
                h1.PrintBarChart();
                Console.WriteLine("\nData set 2:");
                h2.PrintBarChart();
                Console.WriteLine();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////

        // We need a class to pass as a parameter for this exercises, so
        // we're using the 'Television' class
        // PLEASE COPY THIS FROM YOUR PRIOR PCE!
        // I've included just enough code here so that this project compiles, but you'll
        // need the full implementation from the prior class
        public class Television
        {
            public Television() 
            {
            }
            public Television(string br, decimal pr, double si)
            {
            }
        }

        public class TVStorage
        {
            Television[] tvs = new Television[5];

            public TVStorage()
            {
            }

            // TODO: Implement this method!
            // If the location is invalid (negative, or too large) do nothing.
            // If the parameter is null (and the location is ok), then replace
            //      the object reference in the array with null
            public void StoreTV(int iLocation, Television tvToStore)
            {
            }

            // TODO: Implement this method!
            // If the location is invalid (negative, or too large) return null.
            public Television GetTV(int iLocation)
            {
                return new Television(); // odd, but will guarantee all tests fail, to start
            }

            // TODO: Implement this method!
            // If a given slot in the array is non-NULL, then call .Print on it
            // otherwise, print out "Slot X is null", where X is the slot index.
            public void PrintAllTVs()
            {
            }

        }

        public class TVStorage_Demonstration
        {
            public void RunExercise()
            {
                TVStorage tvs = new TVStorage();
                tvs.PrintAllTVs();

                Television t = new Television("Brand X", 1000, 42);
                tvs.StoreTV(2, t);
                tvs.StoreTV(4, new Television("Brand Y", 2000, 52));

                Television t2 = tvs.GetTV(0);
                Console.WriteLine("Is t2 null? (It should be) {0}", t2 == null);

                tvs.PrintAllTVs();

                t2 = tvs.GetTV(2);
                Console.WriteLine("Is t2 the same as t? (It should be) {0}", t2 == t);

            }
        }
        public class Car
        {
            private double weight, tank;
            public Car()
            {
                weight = 0;
                tank = 0;

            }
            public Car(double w, double t)
            {
            if (w>=0)
                weight =w;
                if (t >= 0)
                    tank = t;
            }
            public void SetTankSize(double s)
            {
                if (0<=s)
                tank = s;
               else
                    throw new Exception("Invalid input");
            }
            public double GetTankSize()
            {
                return tank;
            } 
            public void SetWeight(double newWeight)
            {
                if (newWeight >= 0)
                    weight = newWeight;
            }
            public double GetWeight()
            {
                return weight;
            }

            public void Print()
            {
                
                Console.WriteLine("Weight:{0:0.00}",weight);
                Console.WriteLine("Tank:{0:0.00}",tank);
            }
        }


        public class F250 : Car
        {
            private double maxPoundsOfCargo;
            
            public F250()
            {
               
            }
            public F250(double w, double t, double mP): base(w,t)
            {
                maxPoundsOfCargo = mP;
            }

            public double GetCargo()
            {
                return maxPoundsOfCargo;
            }
            public void SetCargo(double c)
            {
                if (c >= 0)
                    maxPoundsOfCargo = c;
                else
                    Console.WriteLine("Bad input");
            }
            public void PrintF250()
            {
                Console.WriteLine("Weight:{0:0.00}",GetWeight());
                Console.WriteLine("Tank Size:{0:0.00}", GetTankSize());
                Console.WriteLine("Max Cargo:{0:0.00}", maxPoundsOfCargo);
            }
        }

        
        public class Z50 : F250
        {
            public Z50(double w, double t, double mP, double rpm):base(w,t,mP)
            {
                maxRPM = rpm;
            }
            public Z50()
            {

            }
            private double maxRPM;
            public double GetMaxRPM()
            {
                return maxRPM;
            }
            public void SetMaxRPM(double rpm)
            {
                if (rpm >= 0)
                    maxRPM = rpm;
                else
                    Console.WriteLine("Bad RPM input");
            }
            public void PrintZ50()
            {
                Console.WriteLine("Weight:{0:0.00}\nTank Size:{1:0.00}",GetWeight(),GetTankSize());
                Console.WriteLine("Max Cargo:{0:0.00}\nMax RPM:{1:0.00}",GetCargo(),GetMaxRPM());
            }
        }

        class Basic_Inheritance
        {
            public void RunExercise()
            {
                Car a = new Car(1250.25, 10.00);
                a.Print();

                F250 cAr = new F250(10.25, 11.291, 12.123);
                cAr.PrintF250();
                cAr.SetCargo(200.75);
                cAr.PrintF250();


                Z50 p = new Z50(10.25,11.25,12.25,13.25);
                p.PrintZ50();
                p.SetWeight(4500.25);
                p.SetTankSize(16.75);
                p.SetMaxRPM(3000.55);
                p.SetCargo(450.45);
                p.PrintZ50();

            
            }
        }

      
        public class HomeElectronicsDevice
        {
            private double devicePrice, deviceWeight;
            public HomeElectronicsDevice(double newPrice, double newWeight)
            {
                if (newWeight >= 0)
                    deviceWeight = newWeight;
                if (newPrice >= 0)
                    devicePrice = newPrice;
            }
            public HomeElectronicsDevice()
            {
                deviceWeight = 0;
                devicePrice = 0;

            }
            public double GetPrice()
            {
                return devicePrice;
            }
            public void SetPrice(double pr)
            {
                if (pr >= 0)
                    devicePrice = pr;
                else
                    Console.WriteLine("Bad price input");
            }
            public double GetWeight()
            {
                return deviceWeight;
            }
            public void SetWeight(double we)
            {
                if (we >= 0)
                    deviceWeight = we;
                else
                    Console.WriteLine("Bad weight input");
            }
            public void Print()
            {
                Console.WriteLine("Price is:{0:0.00}",devicePrice);
                Console.WriteLine("Weight is:{0:0.00}",deviceWeight);
            }
        }
        public class TV : HomeElectronicsDevice
        {
            private double screenSize;
            public TV(double price, double weight, double screen):base(price,weight)
            {
                screenSize = screen;
            }
            public TV()
            {
            }
            public double GetScreen()
            {
                return screenSize;
            }
            public void SetScreen(double sc)
            {
                if (sc >= 0)
                    screenSize = sc;
            }
            public void PrintTV()
            {
                this.Print();
                Console.WriteLine("Screen Size:{0:0.00}",screenSize);
            }
                
        }
        public class GameConsole : HomeElectronicsDevice
        {
            private double clockSpeed;
            public GameConsole(double price, double weight, double cs):base(price,weight)
            {
                clockSpeed = cs;
            }
            public GameConsole()
            {
                clockSpeed = 0;
            }
            public double GetCS()
            {
                return clockSpeed;
            }
            public void SetCS(double c)
            {
                if (c >= 0)
                    clockSpeed = c;
            }
            public void PrintGameConsole()
            {
                this.Print();
                Console.WriteLine("Clock Speed:{0:0.00}",clockSpeed);
            }
        }

        class Constructors_Calling_One_From_Another
        {
            public void RunExercise()
            {
                HomeElectronicsDevice x = new HomeElectronicsDevice(1.25,2.55);
                TV y = new TV(1005.55,123.45,11.76);
                x.Print();
                x.SetPrice(11.55);
                x.SetWeight(18.65);
                x.Print();


                y.PrintTV();


                GameConsole z = new GameConsole(499.95,20.75,2.85);
                    z.PrintGameConsole();
            }
        }

        class Calling_Methods_In_Base_Class
        {
            public void RunExercise()
            {
                Plane x = new Plane(10,12001.50);
                JetPlane y = new JetPlane(10, 12001.55, 20);
                x.Print();
                y.Print();

            }
        }
        public class Plane
        {
            private int numPassangers;
            private double weight;
            public Plane(int num, double wei)
            {
                numPassangers = num;
                weight = wei;
            }
            public Plane()
            {
                numPassangers = 0;
                weight = 0;
            }
            public int GetNumPassangers()
            {
                return numPassangers;
            }
            public double GetWeight()
            {
                return weight;
            }
            public void SetNumPassangers(int p)
            {
                if (p >= 0)
                    numPassangers = p;
            }
            public void SetWeight(double w)
            {
                if (w >= 0)
                    weight = w;
            }
            public void Print()
            {
                Console.WriteLine("NumPassengers:{0}",numPassangers);
                Console.WriteLine("Weight:{0:0.00}",weight);
            }



        }
    
        public class JetPlane:Plane
        {
            private int numEngines;
            public JetPlane(int pass, double weight, int engine):base(pass,weight)
            {
                numEngines = engine;
            }
            public JetPlane()
            {
                numEngines = 0;
            }
            public int GetNumEngines()
            {
                return numEngines;
            } 
            public void SetNumEngines(int e)
            {
                if (e >= 0)
                    numEngines = e;
            }
            new public void Print()
            {
                //What new is doing is telling the IDE that 
                //we are going to be overriding a method that
                //has already been created
                base.Print();
                Console.WriteLine("NumEngines:{0}",numEngines);
                //If leave out the base. C# will thing that we
                //are referring to this. or (this current class)
                //I'm guessing that since we have already declared
                //our method to be new (overriding the previous)
                //the program is looking to pull info from the base
                //class, not this class. 
            }
        }

        class Inheritance_Constructors
        {
            public void RunExercise()
            {
                Saw x = new Saw();
                ElectricSaw y = new ElectricSaw(6,20);
                x.Print();
                y.Print();
            }
        }
        public class Saw
        {
           private int sharp;
            public Saw()
            {
                sharp = 5;
            }
            public Saw(int s)
            {
                if (s < 11 && s > 0)
                    sharp = s;
            }
            public int GetSharp()
            {
                return sharp;
            }
            public void SetSharp(int sh)
            {
                if (sh < 11 && sh > 0)
                    sharp = sh;
            }
            public void Print()
            {
                Console.WriteLine("Sharpness Rating:{0}",sharp);
            }
        }
        public class ElectricSaw:Saw
        {
            private int cordLength;
            public ElectricSaw()
            {
                cordLength = 0;
            }
            public ElectricSaw(int sharp):base(sharp)
            {
                sharp = 6;
            }
            public ElectricSaw(int shar, int cord):base(shar)
            {
                cordLength = cord;
            }
            new public void Print()
            {
                base.Print();
                Console.WriteLine("Cord Length:{0}", cordLength);
            }
        }

        // The comments you need to fill in are inside RunExercise, below:
        class Explain_Basic_Polymorphism
        {
            public void RunExercise()
            {
                BaseClass bcRef1 = new BaseClass();
                BaseClass bcRef2 = new DerrivedClassOne();
                BaseClass bcRef3 = new TheOtherDerrivedClass();

                Console.WriteLine("variables is of type BaseClass, object is of type BaseClass:");
                bcRef1.VirtualMethod1();
                // What output does the prior line produce?  Paste it in here:
                //
                //
                //variables is of type BaseClass, object is of type BaseClass:
                //BaseClass.VirtualMethod1!

                // Why does bcRef1.VirtualMethod1 produce that output?  Which method is it calling, and why?
                // YOUR ANSWER: Because it evokes the Virtual method1 which produces that result in the BaseClass
                //
                bcRef1.VirtualMethodTWO();
                // What output does the prior line produce?  Paste it in here:
                //BaseClass.VirtualMethodTWO!

                // Why does bcRef1.VirtualMethodTWO produce that output?  Which method is it calling, and why?
                // YOUR ANSWER:
                //

                Console.WriteLine("variables is of type BaseClass, object is of type DerrivedClassOne:");
                bcRef2.VirtualMethod1();
                // What output does the prior line produce?  Paste it in here:
                //DerrivedClassOne.VirtualMethod1
                //BaseClass.VirtualMethod1!

                // Why does bcRef2.VirtualMethod1 produce that output?  Which method is it calling, and why?
                // YOUR ANSWER: It will call the new method with the new input, but also include the console line from VM1
                //
                bcRef2.VirtualMethodTWO();
                // What output does the prior line produce?  Paste it in here:
                //BaseClass.VirtualMethodTWO!

                // Why does bcRef2.VirtualMethodTWO produce that output?  Which method is it calling, and why?
                // YOUR ANSWER: Because this can call into the original class to pull that VMTWO method
                //

                Console.WriteLine("variables is of type BaseClass, object is of type TheOtherDerrivedClass:");
                bcRef3.VirtualMethod1();
                // What output does the prior line produce?  Paste it in here:
                //BaseClass.VirtualMethod1!

                // Why does bcRef3.VirtualMethod1 produce that output?  Which method is it calling, and why?
                // YOUR ANSWER:
                //
                bcRef3.VirtualMethodTWO();
                // What output does the prior line produce?  Paste it in here:
                //TheOtherDerrivedClass.VirtualMethodTWO

                // Why does bcRef3.VirtualMethodTWO produce that output?  Which method is it calling, and why?
                // YOUR ANSWER:
                //
            }
        }
        class BaseClass
        {
            public virtual void VirtualMethod1()
            {
                Console.WriteLine("BaseClass.VirtualMethod1!");
            }
            // This is here just to show you that virtual & public can be in either order
            // void (the return type) needs to go immediately prior to the method name, though
            // (try something like public void virtual, and note the compiler errors you get)
            //MEMBER MODIFIER VIRTUAL MUST PRECED THE MEMBER TYPE AND NAME
           
            virtual public void VirtualMethodTWO()
            {
                Console.WriteLine("BaseClass.VirtualMethodTWO!");
            }
        }
        class DerrivedClassOne : BaseClass
        {
            public override void VirtualMethod1()
            {
                Console.WriteLine("DerrivedClassOne.VirtualMethod1");
                base.VirtualMethod1();
            }
        }
        class TheOtherDerrivedClass : BaseClass
        {
            public override void VirtualMethodTWO()
            {
                Console.WriteLine("TheOtherDerrivedClass.VirtualMethodTWO");
            }
        }

        public class Create_Basic_Polymorphic_Method
        {
            public void RunExercise()
            {
            }
        }

        public class LightBulb
        {
            virtual public double CalculateLight(double amps)
            {
                // We want to start by returning something that will cause the tests to fail.
                // Not A Number (NaN) is a good choice for that :)
                return 0;
            }
            virtual public double CalculateHeat(double amps)
            {
                return 0;
            }
        }
        public class IncandescentLightBulb : LightBulb
        {
            public override double CalculateLight(double amps)
            {
                return Math.Pow(amps * 3 + 1, 2) / amps;
            }
            public override double CalculateHeat(double amps)
            {
                return Math.Sqrt(amps * 7);
            }
        }
        public class FluorescentLightBulb : LightBulb
        {
            public override double CalculateLight(double amps)
            {
                return Math.Pow(amps, 2) *3;
            }
            public override double CalculateHeat(double amps)
            {
                return Math.Sqrt(Math.Sqrt(amps * 7));
            }
        }


        class Polymorphism_And_Arrays
        {
            public void RunExercise()
            {
                // This will create 10 spaces, each of which is a blank reference to 
                // a GeneralPrinter.
                GeneralPrinter[] gps = new GeneralPrinter[10];

                gps[1] = new GeneralPrinter();
                gps[2] = new GeneralPrinter(21);
                gps[3] = new SpecificPrinter();
                gps[4] = new SpecificPrinter();
                gps[6] = new GeneralPrinter(1111111);
                gps[7] = new SpecificPrinter();
               

                for (int i = 0; i < gps.Length; i++)
                {
                    if (gps[i] != null)
                        gps[i].PrintTheMessage();
                }
            }
        }
        public class GeneralPrinter
        {
            private int data; // mostly, we just want to see that there are, in fact,
            // separate objects

            public GeneralPrinter()
            {
                data = 99;
            }
            public GeneralPrinter(int n) // in case you want to create a GP with a specific data value...
            {
                data = n;
            }
            virtual public void PrintTheMessage()
            {
                Console.WriteLine("GeneralPrinter.PrintTheMessage: This is my general message.  My data:{0}", data);
            }
        }
        public class SpecificPrinter : GeneralPrinter
        {
            public override void PrintTheMessage()
            {
                Console.WriteLine("Message from a SpecificPrinter object!");
            }
        }


        class Overriding_ToString
        {
            public void RunExercise()
            {
                MyPoint p = new MyPoint(3, 7.6);
                
                Console.WriteLine("Your point is at:" + p.ToString());
                Console.WriteLine("Your point is at:{0}", p.ToString());
                Console.WriteLine("Your point is at:" + p);
                Console.WriteLine("Your point is at:{0}", p);
            }
        }
        public class MyPoint 
        {
            double x;
            double y;
            public MyPoint(double nX, double nY)
            {
                x = nX;
                y = nY;
            }
            double getX() { return x; }
            void setX(double nx) { x = nx; }

            double getY() { return y; }
            void setY(double ny) { y = ny; }
            public override string ToString() { return String.Format("({0:0.0},{1:0.0})", x, y); }
            
        }

        class ToString_And_Arrays
        {
            public void RunExercise()
            {
                //Object[] objs = new Object[4];
                //objs[0] = new MyPoint(1, 2);
                //objs[1] = new IncandescentLightBulb(10) ; // amps, maybe?
                //objs[2] = new MyPoint(4, 7);
                //objs[3] = new IncandescentLightBulb(20) ; // amps, maybe?

                //for (int i = 0; i < objs.Length; i++)
                //{
                //    string s = objs[i].ToString();
                //    Console.WriteLine(s);
                //}
            }
        }
    }
}