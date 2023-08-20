[System.Serializable]
public class DialogueObject
{
    //dialogue chunkus among us? somtin liek dat
    public Part[] parts;


    //this be the func that gets part from parts    
    public Part GetPart(string id)
    {
        return System.Array.Find(parts, part => part.ID == id);   //linq like stuff in the system.array... fun stuff
    }

    [System.Serializable]
    public class Part
    {
        public string ID;  //dialogue id.. for knowing purposes... think of it like index
        public string text;    //magical stuff
        public string nextId;   //where will the next part head to?
        public Response[] responses;   //player say No to drugs

        [System.Serializable]
        public class Response
        {
            public string text;  //the response also have text "Say no to drugs"
            public string ID;   // the id for knowing purposes
        }
    }
}