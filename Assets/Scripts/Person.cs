﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour {
    
    private int age;
    private string personName;
    private string interests;

    private System.Action<Person> killCallback;
    public void SetKillCallback(System.Action<Person> callback)
    {
        killCallback = callback;
    }

    private static readonly string[] firstNames = new string[]
    {
        "Maria",
"Elisabeth",
"Anna",
"Kristina",
"Margareta",
"Eva",
"Birgitta",
"Karin",
"Linnéa",
"Marie",
"Ingrid",
"Sofia",
"Marianne",
"Lena",
"Kerstin",
"Helena",
"Sara",
"Emma",
"Katarina",
"Johanna",
"Inger",
"Viktoria",
"Cecilia",
"Monica",
"Susanne",
"Elin ",
"Therese",
"Jenny",
"Anita",
"Irene",
"Hanna",
"Louise",
"Carina",
"Ulla",
"Ann",
"Gunilla",
"Ingegerd",
"Linda",
"Viola",
"Helen",
"Ida ",
"Malin",
"Annika",
"Matilda",
"Elsa",
"Ulrika",
"Josefin",
"Anette",
"Sofie",
"Barbro",
"Astrid",
"Alice",
"Anneli",
"Julia",
"Caroline",
"Kristin",
"Emelie",
"Siv",
"Karolina",
"Åsa",
"Lisa",
"Camilla",
"Amanda ",
"Madeleine",
"Yvonne",
"Lovisa",
"Erika",
"Britt",
"Agneta",
"Charlotte",
"Rut",
"Gun",
"Sandra",
"Maja",
"Rebecca",
"Frida",
"Berit",
"Alexandra",
"Ellinor",
"Isabelle ",
"Jessica",
"Emilia",
"Ann-Marie",
"Ebba",
"Inga",
"Ellen",
"Märta",
"Charlotta",
"Klara",
"Sonja",
"Ingeborg",
"Olivia",
"Ann-Christin",
"Birgit",
"Maj",
"Pia",
"Agnes",
"Mona",
"Gunnel",
"Lisbeth",
"Karl",
"Erik",
"Lars",
"Anders",
"Per",
"Mikael",
"Johan",
"Olof",
"Nils ",
"Jan",
"Gustav",
"Hans",
"Lennart",
"Peter",
"Gunnar",
"Sven",
"Fredrik",
"Thomas",
"Bengt",
"Daniel",
"Bo",
"Alexander",
"Oskar",
"Göran",
"Åke",
"Christer",
"Andreas",
"Stefan",
"Magnus",
"Martin",
"John",
"Mats",
"Mattias",
"Henrik",
"Leif",
"Ulf",
"Jonas",
"Björn",
"Axel",
"Bertil",
"Mohamed",
"Arne",
"Robert",
"Ingemar",
"Christian",
"Marcus",
"David",
"Viktor",
"Niklas",
"Emil",
"Kjell",
"Patrik",
"Håkan",
"Stig",
"Rickard",
"Rolf",
"Christoffer",
"Joakim",
"Wilhelm",
"Tommy",
"William",
"Filip",
"Roland",
"Claes",
"Simon",
"Sebastian",
"Roger",
"Ingvar",
"Anton",
"Kent",
"Ove",
"Johannes",
"Tobias",
"Kenneth",
"Jakob",
"Jonathan",
"Emanuel",
"Jörgen",
"Hugo ",
"Elias",
"Robin",
"Kurt",
"Lucas",
"Adam",
"Rune",
"Gösta",
"Georg",
"Johnny",
"Ali",
"Linus",
"Josef",
"Sten",
"Oliver",
"Torbjörn",
"Arvid",
"Isak",
"Dan",
"Ludvig",
"Albin",
"Alf",
    };

    private static readonly string[] lastNames = new string[] {
    "Johansson",
"Engström",
"Andersson",
"Lundin",
"Karlsson",
"Fransson",
"Nilsson",
"Eklund",
"Eriksson",
"Lind",
"Larsson",
"Johnsson",
"Olsson",
"Samuelsson",
"Persson",
"Gunnarsson",
"Svensson",
"Holm",
"Gustafsson",
"Bergman",
"Pettersson",
"Nyström",
"Jonsson",
"Holmberg",
"Jansson",
"Lundqvist",
"Hansson",
"Arvidsson",
"Bengtsson",
"Mårtensson",
"Jönsson",
"Isaksson",
"Petersson",
"Nyberg",
"Carlsson",
"Söderberg",
"Gustavsson",
"Björk",
"Magnusson",
"Nordström",
"Lindberg",
"Lundström",
"Olofsson",
"Eliasson",
"Lindström",
"Wallin",
"Axelsson",
"Berggren",
"Lindgren",
"Björklund",
"Jakobsson",
"Ström",
"Lundberg",
"Hermansson",
"Bergström",
"Nordin",
"Lundgren",
"Sandström",
"Berglund",
"Holmgren",
"Berg",
"Sundberg",
"Fredriksson",
"Ekström",
"Mattsson",
"Åberg",
"Sandberg",
"Hedlund",
"Henriksson",
"Sjögren",
"Håkansson",
"Månsson",
"Sjöberg",
"Martinsson",
"Forsberg",
"Öberg",
"Lindqvist",
"Jonasson",
"Danielsson",
"Andreasson" };

    private static readonly string[] allInterests = new string[]
    {
        "3D printing",
"Acrobatics",
"Acting",
"Amateur radio",
"Animation",
"Aquascaping",
"Baking",
"Baton twirling",
"Beatboxing",
"Board/tabletop games",
"Book restoration",
"Cabaret",
"Calligraphy",
"Candle making",
"Coffee roasting",
"Collecting",
"Coloring",
"Computer programming",
"Cooking",
"Cosplaying",
"Couponing",
"Creative writing",
"Crocheting",
"Cross-stitch",
"Crossword puzzles",
"Cryptography",
"Dance",
"Digital arts",
"Do it yourself",
"Drama",
"Drawing",
"Electronics",
"Embroidery",
"Fantasy sports",
"Fashion",
"Fishkeeping",
"Flower arranging",
"Foreign language learning",
"Gaming (tabletop games and role-playing games)",
"Genealogy",
"Glassblowing",
"Graphic design",
"Gunsmithing",
"Herp keeping",
"Homebrewing",
"Hydroponics",
"Ice skating",
"Jewelry making",
"Jigsaw puzzles",
"Juggling",
"Knife making",
"Knitting",
"Kombucha brewing",
"Lace making",
"Lapidary",
"Leather crafting",
"Lego building",
"Listening to music",
"Machining",
"Macrame",
"Magic",
"Metalworking",
"Model building",
"Model engineering",
"Needlepoint",
"Origami",
"Painting",
"Philately",
"Photography",
"Playing musical instruments",
"Poi",
"Pottery",
"Puzzles",
"Quilling",
"Quilting",
"Reading",
"Robot combat",
"Scrapbooking",
"Sculpting",
"Sewing",
"Singing",
"Sketching",
"Soapmaking",
"Stand-up comedy",
"Table tennis",
"Taxidermy",
"Video game developing",
"Video gaming",
"Video editing",
"Watching movies",
"Watching television",
"Whittling",
"Wood carving",
"Woodworking",
"Worldbuilding",
"Writing",
"Yo-yoing",
"Yoga",
"Outdoor hobbies",
"Air sports",
"Archery",
"Astronomy",
"BASE jumping",
"Baseball",
"Basketball",
"Beekeeping",
"Bird watching",
"Blacksmithing",
"BMX",
"Board sports",
"Bodybuilding",
"Brazilian jiu-jitsu",
"Camping",
"Canoeing",
"Canyoning",
"Dowsing",
"Driving",
"Fishing",
"Flag football",
"Flying",
"Flying disc",
"Foraging",
"Freestyle football",
"Gardening",
"Geocaching",
"Ghost hunting",
"Graffiti",
"Handball",
"High-power rocketry",
"Hiking",
"Hooping",
"Horseback riding",
"Hunting",
"Inline skating",
"Jogging",
"Kayaking",
"Kite flying",
"Kitesurfing",
"LARPing",
"Letterboxing",
"Longboarding",
"Martial arts",
"Metal detecting",
"Motor sports",
"Mountain biking",
"Mountaineering",
"Mushroom hunting/mycology",
"Netball",
"Nordic skating",
"Orienteering",
"Paintball",
"Parkour",
"Photography",
"Polo",
"Powerlifting",
"Rafting",
"Rappelling",
"Road biking",
"Rock climbing",
"Roller skating",
"Rugby",
"Running",
"Sailing",
"Sand art",
"Scouting",
"Scuba diving",
"Sculling or rowing",
"Shooting",
"Shopping",
"Skateboarding",
"Skiing",
"Skimboarding",
"Skydiving",
"Slacklining",
"Snowboarding",
"Stone skipping",
"Sun bathing",
"Surfing",
"Swimming",
"Taekwondo",
"Tai chi",
"Topiary",
"Travel",
"Urban exploration",
"Vacation",
"Vehicle restoration",
"Walking",
"Water sports",
"Collection hobbies",
"Indoors",
"Action figure",
"Antiquing",
"Art collecting",
"Book collecting",
"Card collecting",
"Coin collecting",
"Comic book collecting",
"Deltiology (postcard collecting)",
"Die-cast toy",
"Dolls",
"Element collecting",
"Knife collecting",
"Movie and movie memorabilia collecting",
"Perfume",
"Phillumeny",
"Rail transport modelling",
"Record collecting",
"Shoes",
"Stamp collecting",
"Video game collecting",
"Vintage cars",
"Outdoors",
"Antiquities",
"Auto audiophilia",
"Flower collecting and pressing",
"Fossil hunting",
"Insect collecting",
"Magnet fishing",
"Metal detecting",
"Mineral collecting",
"Rock balancing",
"Sea glass collecting",
"Seashell collecting",
"Stone collecting",
"Competitive hobbies",
"Indoors",
"Animal fancy",
"Badminton",
"Baton twirling",
"Billiards",
"Bowling",
"Boxing",
"Bridge",
"Cheerleading",
"Chess",
"Color guard",
"Curling",
"Dancing",
"Darts",
"Debate",
"Eating",
"ESports",
"Fencing",
"Go",
"Gymnastics",
"Ice skating",
"Kabaddi",
"Laser tag",
"Longboarding",
"Mahjong",
"Marbles",
"Martial arts",
"Poker",
"Shogi",
"Slot car racing",
"Speedcubing",
"Sport stacking",
"Table football",
"Volleyball",
"Weightlifting",
"Wrestling",
"Outdoors",
"Airsoft",
"American football",
"Archery",
"Association football",
"Astrology",
"Australian rules football",
"Auto racing",
"Baseball",
"Beach volleyball",
"Breakdancing",
"Climbing",
"Cricket",
"Cycling",
"Disc golf",
"Dog sport",
"Equestrianism",
"Exhibition drill",
"Field hockey",
"Figure skating",
"Fishing",
"Footbag",
"Golfing",
"Handball",
"Horseback riding",
"Ice hockey",
"Judo",
"Jukskei",
"Kart racing",
"Knife throwing",
"Lacrosse",
"Longboarding",
"Marching band",
"Model aircraft",
"Racquetball",
"Radio-controlled car racing",
"Roller derby",
"Rugby league football",
"Sculling or rowing",
"Shooting sport",
"Skateboarding",
"Speed skating",
"Squash",
"Surfing",
"Swimming",
"Table tennis",
"Tennis",
"Tennis polo",
"Tether car",
"Tour skating",
"Triathlon",
"Ultimate frisbee",
"Volleyball",
"Water polo",
"Observation hobbies",
"Indoors",
"Fishkeeping",
"Learning",
"Meditation",
"Microscopy",
"Reading",
"Shortwave listening",
"Videophilia",
"Outdoors",
"Aircraft spotting",
"Amateur astronomy",
"Birdwatching",
"Bus spotting",
"Geocaching",
"Gongoozling",
"Herping",
"Hiking/backpacking",
"Meteorology",
"Photography",
"Satellite watching",
"Trainspotting",
"Traveling",
"Whale watching",

    };

    bool alive = true;

    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    private const float velocity = 1.5f;

    void Update () {
        if (!alive) return;
        if (OnTarget)
        {
            if (!path) return;
            pathTarget = path.GetTarget(pathTargetIdx);
            pathTargetIdx++;
            if (pathTarget == null)
            {
                alive = false;
                gameObject.SetActive(false);
                if (killCallback != null) killCallback(this);
                return;
            }
        }
        Vector3 offset = pathTarget.position - rb.transform.position;
        offset.y = 0;
        rb.transform.LookAt(pathTarget, Vector3.up);
        rb.velocity = offset.normalized * velocity;
    }
    
    float onTargetThreshold = 0.05f;
    public bool OnTarget
    {
        get
        {
            if (pathTarget == null) return true;
            Vector3 offset = rb.transform.position - pathTarget.position;
            offset.y = 0;
            return offset.sqrMagnitude < onTargetThreshold;
        }
    }

    public void Kill(Vector3 forcePosition, Vector3 forceVector)
    {
        alive = false;
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForceAtPosition(forceVector, forcePosition);
        StartCoroutine(_Kill());
    }

    public bool IsAlive
    {
        get
        {
            return alive;
        }
    }

    IEnumerator<WaitForSeconds> _Kill()
    {
        yield return new WaitForSeconds(2f);
        if (killCallback != null) killCallback(this);
        gameObject.SetActive(false);
    }

    string[] messages = new string[] {
        "{0} (age {2}) got run over by a train.",
        "In loving memory of {0}, who loved {1}.",
        "Trains claimed another victim ({0}, age {2}).",
    };

    public string KillMessage
    {
        get
        {
            return string.Format(messages[Random.Range(0, messages.Length)], personName, interests, age);
        }
    }
    
    public void Recycle()
    {
        alive = true;
        age = Random.Range(1, 100);
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        rb.transform.rotation = Quaternion.identity;
        personName = string.Format("{0} {1}", firstNames[Random.Range(0, firstNames.Length)], lastNames[Random.Range(0, lastNames.Length)]);
        interests = allInterests[Random.Range(0, allInterests.Length)].ToLower();
        gameObject.SetActive(true);
        
    }

    WalkPath path;
    int pathTargetIdx = 0;
    Transform pathTarget;

    public void SetWalkingPath(WalkPath path)
    {
        this.path = path;        
        pathTargetIdx = 0;
        pathTarget = null;
    }

    public void SetPersonPosition(Vector3 position)
    {
        Vector3 offset = transform.position - rb.transform.position;
        transform.position = position + offset;
    }
}
