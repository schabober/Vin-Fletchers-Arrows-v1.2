Console.Title = "Vin Fletchers Arrows v1.2";
//updated for Vin's Trouble
//updated for The Properties of Arrows
//updated for Arrow Factories
Console.WriteLine("Welcome to Vin Fletchers Arrows");
Console.WriteLine("Select an arrow.");
Console.WriteLine("1 - Elite Arrow. \n2 - Beginner Arrow. \n3 - Marksman Arrow. \n4 - Custom Arrow.");
Arrow arrow = ArrowBuilder.CreateEliteArrow(); 
bool validInput = false;
while (!validInput)
{
    string theirInput = Console.ReadLine();
    switch (theirInput)
    {
    case "1":
        arrow = ArrowBuilder.CreateEliteArrow();
        validInput = true;
        break;
    case "2":
        arrow = ArrowBuilder.CreateBeginnerArrow();
        validInput = true;
        break;
    case "3":
        arrow = ArrowBuilder.CreateMarksmanArrow();
        validInput = true;
        break;
    case "4":
        arrow = new ArrowBuilder().MakeCustomArrow();
        validInput = true;
        break;
    default:
        Console.WriteLine("You did not enter a valid option, try again.");
    break;
    }

}

Console.WriteLine($"You Selected {arrow.ArrowHead} head with {arrow.ArrowFletching} fletching at {arrow.ArrowLength}cm length. "); 
Console.WriteLine($"Your total cost is {arrow.TotalCost} gold.");
Console.ReadKey(true);


/*    if (theirInput.ToLower() == "yes" )
    {
        ArrowBuilder build = new ArrowBuilder();
        Arrow arrow = build.MakeCustomArrow();
        Console.WriteLine($"You Selected {arrow.ArrowHead} head with {arrow.ArrowFletching} fletching at {arrow.ArrowLength}cm length. "); 
        Console.WriteLine($"Your total cost is {arrow.TotalCost} gold.");
        ArrowBuilder build2 = new ArrowBuilder();
        Arrow arrow2 = build2.MakeCustomArrow();
        Console.WriteLine($"You selected {arrow2.ArrowHead} head with {arrow2.ArrowFletching} fletching at {arrow2.ArrowLength}cm length. ");
        Console.WriteLine($"Your total cost is {arrow2.TotalCost} gold.");
        Console.ReadKey(true);
        
    }
*/

    public class Arrow
    {
        
            //private fields with an _underScore
        // private float _totalCost;
        // private ArrowHeads _arrowHead;
        // private float _arrowLength;
        private ArrowFletching _arrowFletching;
            //private fields with an _underScore
        
        //auto properties take the job of respective fields
            //public properties with UpperCamelCase
        public float TotalCost { get; private set; } //_totalCost;
        public ArrowHeads ArrowHead { get; } //_arrowHead;
        public float ArrowLength { get; } //_arrowLength;
        public string ArrowFletching => AddSpace(_arrowFletching);
            //public properties with UpperCamelCase
        public Arrow(ArrowHeads head,ArrowFletching fletching,float length)
        {
            ArrowHead = head;
            _arrowFletching = fletching;
            ArrowLength = length;
            ArrowValue();
        }
        private float ArrowValue()
        {
            float _cost = 0f;
        
            switch (ArrowHead)
            {
                case ArrowHeads.Steel:
                    _cost += 10f;
                    break;
                case ArrowHeads.Obsidian:
                    _cost += 5f;
                    break;
                case ArrowHeads.Wood:
                    _cost += 3f;
                    break;
            }

            switch (_arrowFletching)
            {
                case global::ArrowFletching.Plastic:
                    _cost += 10f;
                    break;
                case global::ArrowFletching.TurkeyFeathers:
                    _cost += 5f;
                    break;
                case global::ArrowFletching.GooseFeathers:
                    _cost += 3f;
                    break;
            }

            _cost += (ArrowLength * .05f);
            TotalCost = _cost;
            return TotalCost;
        }

        private string AddSpace(ArrowFletching fletching)
        {
            switch (fletching)
            {
                case global::ArrowFletching.TurkeyFeathers:
                    return "Turkey Feathers";
                case global::ArrowFletching.GooseFeathers:
                    return "Goose Feathers";
                default:
                    return fletching.ToString();
            }
        }


    }

public class ArrowBuilder
{
    //fields for all methods
    private ArrowHeads arrowHead;
    private ArrowFletching arrowFletching;
    private float arrowLength;
    //fields for all methods

    public Arrow MakeCustomArrow()//method to get all data
    {
        GetArrowHead();
        GetArrowFletching();
        GetArrowLength();
        return new Arrow(arrowHead, arrowFletching, arrowLength);
    }
        private void GetArrowHead()
        {
            while (true) // selecting the arrowhead type

            {
                Console.Write("Which kind of arrow head do you wish to have? I have Steel, Obsidian and Wood. ");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "steel":
                        arrowHead = ArrowHeads.Steel;
                        break;
                    case "wood":
                        arrowHead = ArrowHeads.Wood;
                        break;
                    case "obsidian":
                        arrowHead = ArrowHeads.Obsidian;
                        break;
                    default:
                        Console.WriteLine("You did not enter a valid option, try again.");
                        continue;
                }

                break;
            }
        }

        private void GetArrowFletching()
        {
            while (true) // selecting the fletching type
            {
                Console.Write("Select a fletching type. We have Plastic, Turkey Feathers and Goose Feathers. ");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "plastic":
                        arrowFletching = ArrowFletching.Plastic;
                        break;
                    case "turkey feathers":
                        arrowFletching = ArrowFletching.TurkeyFeathers;
                        break;
                    case "goose feathers":
                        arrowFletching = ArrowFletching.GooseFeathers;
                        break;
                    default:
                        Console.WriteLine("You did not enter a valid option, try again.");
                        continue;
                }

                break;

            }
        }

        private void GetArrowLength()
        
        {
            //length selection
            do
            {
                Console.Write("Which length arrow are you looking to get I can only make 60 - 100cm lengths. ");
                arrowLength = Convert.ToSingle(Console.ReadLine());
            } while (arrowLength > 100 || arrowLength < 60);
        }




         public static Arrow CreateEliteArrow()
         //arrow is the return type
        {
            return new Arrow(ArrowHeads.Steel, ArrowFletching.Plastic, 95);
        }
         
        public static Arrow  CreateBeginnerArrow()
        {
            return new Arrow(ArrowHeads.Wood, ArrowFletching.GooseFeathers, 75);
        }
         
        public static Arrow CreateMarksmanArrow()
        {
            return new Arrow(ArrowHeads.Steel, ArrowFletching.GooseFeathers, 65);
        }
}



public enum ArrowHeads

{
    Steel,
    Wood,
    Obsidian
}

public enum ArrowFletching
{
    Plastic,
    TurkeyFeathers,
    GooseFeathers
}