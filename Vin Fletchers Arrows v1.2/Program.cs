Console.Title = "Vin Fletchers Arrows v1.2";
//updated for Vin's Trouble
Console.WriteLine("Welcome to Vin Fletchers Arrows");
Console.WriteLine("Would you like to build an arrow? yes or no?");
string theirInput = Console.ReadLine();
    if (theirInput.ToLower() == "yes")
    {
        ArrowBuilder build = new ArrowBuilder();
        Arrow arrow = build.MakeCustomArrow();
        Console.WriteLine($"You Selected {arrow.ReadArrowHead} head with {arrow.ReadArrowFletching} fletching at {arrow.ReadArrowLength}cm length. "); 
        Console.WriteLine($"Your total cost is {arrow.ReadTotalCost} gold.");
        ArrowBuilder build2 = new ArrowBuilder();
        Arrow arrow2 = build2.MakeCustomArrow();
        
        Console.WriteLine($"You selected {arrow2.ReadArrowHead} head with {arrow2.ReadArrowFletching} fletching at {arrow2.ReadArrowLength}cm length. ");
        Console.WriteLine($"Your total cost is {arrow2.ReadTotalCost} gold.");
        Console.ReadKey(true);
        
    }


public class Arrow
{
    private float totalCost;
    private ArrowHeads arrowHead;
    private ArrowFletching arrowFletching;
    private float arrowLength;
    public float ReadTotalCost => totalCost;
    public ArrowHeads ReadArrowHead => arrowHead;
    public float ReadArrowLength => arrowLength;
    public string ReadArrowFletching => AddSpace(arrowFletching);
    public Arrow(ArrowHeads head,ArrowFletching fletching,float length)
    {
        arrowHead = head;
        arrowFletching = fletching;
        arrowLength = length;
        ArrowValue();
    }
    private float ArrowValue()
    {
        float _cost = 0f;
        
        switch (arrowHead)
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

        switch (arrowFletching)
        {
            case ArrowFletching.Plastic:
                _cost += 10f;
                break;
            case ArrowFletching.TurkeyFeathers:
                _cost += 5f;
                break;
            case ArrowFletching.GooseFeathers:
                _cost += 3f;
                break;
        }

        _cost += (arrowLength * .05f);
        totalCost = _cost;
        return totalCost;
    }

    private string AddSpace(ArrowFletching fletching)
    {
        switch (fletching)
        {
            case ArrowFletching.TurkeyFeathers:
                return "Turkey Feathers";
            case ArrowFletching.GooseFeathers:
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
                Console.Write(
                    "Which kind of arrow head do you wish to have? I have steel, wood and obsidian. ");
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