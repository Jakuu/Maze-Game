
//Jason Hamilton

//public class ObjectiveCollection : MonoBehaviour
//{
//    // For later implementation of objective list, for now will only have one objective
//    //public List<IObjective> objectives = new List<IObjective>();
//}

public interface IObjective
{
    bool isComplete();
    void Complete();
    string getRequirements();
}
