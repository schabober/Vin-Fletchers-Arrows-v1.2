Console.Title = "Vin Fletchers Arrows v1.2";
//updated for Vin's Trouble
//updated for the properties of arrows
Console.WriteLine("Welcome to Vin Fletchers Arrows");
Console.WriteLine("Would you like to build an arrow? yes or no?");
string theirInput = Console.ReadLine();
    if (theirInput.ToLower() == "yes")
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


public class Arrow
{
    //private fields with an _underScore
    private float _totalCost;
    private ArrowHeads _arrowHead;
    private ArrowFletching _arrowFletching;
    private float _arrowLength;
    //private fields with an _underScore
    
    //public properties with UpperCamelCase
    public float TotalCost { get; private set; } //_totalCost;

    public ArrowHeads ArrowHead { get; private set; } //_arrowHead;
    public float ArrowLength { get; private set; } //_arrowLength;

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
                Console.Write("Which kind of arrow head do you wish to have? I have steel, wood and obsidian. ");
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
                Console.Write("Select a fletching type. We have plastic, turkey feathers and goose feathers. ");
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