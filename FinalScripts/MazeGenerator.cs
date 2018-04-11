//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * https://blackeagleproject.wordpress.com/2015/10/02/tutoriel-n2-partie-1-creation-du-projet-unity-et-creation-du-prefab-necessaire-a-la-generation-du-labyrinthe-2/
 * The Maze generation scripts were taken from this tutorial and modified based on our requierements
 * 
 **/
public class MazeGenerator : MonoBehaviour {

     int width, height; //maze size

    public VisualCell visualCellPrefab; //cell prefab

    public Cell[,] cells; //virtual cell array

    private Vector2 randomCellPos;
    private VisualCell visualCellInst;

    private List<CellAndRelativePosition> neighbors;

    public Material cornerMat;

    public Material startMat;
    public Material endMAt;

    Material floorFinal;
    Material wallFinal;

    public GameObject playerSpawner;
    public GameObject chestPrefab;
    public VisualCell[] obstacles;
    public Material obstacleFloor;
    public AudioClip[] audios;
    AudioSource AS;
    public Material[] floorMaterialArray = new Material[3];
    public Material[] wallMaterialArray = new Material[7];
    public Material[] skyMaterials = new Material[13];

    float ObsInt;
    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }

    void Start () {
        AS.clip = audios[PlayerPrefs.GetInt("Difficulty")]; //set music based on difficulty
        width = PlayerPrefs.GetInt("MazeSize"); //get the maze size
        height = PlayerPrefs.GetInt("MazeSize");//get the maze size

        if (PlayerPrefs.GetInt("Difficulty")==0) {
            ObsInt = .15f; // % chance of obstacle
            
        }
        if (PlayerPrefs.GetInt("Difficulty") == 1)
        {
            ObsInt = .25f; // % chance of obstacle

        }
        if (PlayerPrefs.GetInt("Difficulty") == 2)
        {
            ObsInt = .50f; // % chance of obstacle


        }
        if (PlayerPrefs.GetInt("Difficulty") == 3)
        {
            ObsInt = 1f; // % chance of obstacle

        }
        cells = new Cell[width, height]; // create new cell array
        Init();
        AS.Play();
	}
	//define the passages and if they are an obstacle or not
    void Init()
    {

        for(int i = 0; i <width; i++)
        {

            for (int j = 0; j < height; j++)
            {
                bool obs = false;
                float ranD = Random.Range(0, width*width);
               // Debug.Log(i, j);
                if ((ranD < (width*width)* ObsInt)) {
                    //Debug.Log(i+ " " + j);

                    if ((i == 0 && j == 0)||(i==0 && j==height-1)||(i==width-1 && j==0)||(i==width-1 && j== height-1))
                    {
                        obs = false;
                    }
                    else {

                        obs = true;
                    }
                    
                }

                cells[i, j] = new Cell(false, false, false, false, false, obs);
                cells[i, j].xPos = i;
                cells[i, j].zPos = j;
            }
        }
        RandomCell();
        GetRandomMaterials();
        ChangeSkyBox();
        InitVisualCell();

        InstantiateSpawnersPrefab();
        //SpawnChests();
        
    }

    //pick a random material for the walls and floor
    private void GetRandomMaterials()
    {
        floorFinal = floorMaterialArray[Random.Range(0, floorMaterialArray.Length)];
        wallFinal = wallMaterialArray[Random.Range(0, wallMaterialArray.Length)];
    }
    //pick a random starting point in the cell array to start the algorithm
    void RandomCell()
    {
        randomCellPos = new Vector2((int)Random.Range(0, width), (int)Random.Range(0, height));

        GenerateMaze((int)randomCellPos.x, (int)randomCellPos.y);
    }
    //iterate through cells and create passages
    void GenerateMaze(int x, int y)
    {
        Cell currentCell = cells[x, y];
        neighbors = new List<CellAndRelativePosition>();
        if (currentCell.visited == true) return;
        currentCell.visited = true;

        if(x + 1 < width && cells[x +1, y].visited == false)
        {
            neighbors.Add(new CellAndRelativePosition(cells[x + 1, y], CellAndRelativePosition.Direction.East));
        }
        if (y + 1 < height && cells[x, y + 1].visited == false)
        {
            neighbors.Add(new CellAndRelativePosition(cells[x, y + 1], CellAndRelativePosition.Direction.South));
        }
        if (x - 1 >= 0 && cells[x - 1, y].visited == false)
        {
            neighbors.Add(new CellAndRelativePosition(cells[x - 1, y], CellAndRelativePosition.Direction.West));
        }
        if (y - 1 >= 0 && cells[x, y - 1].visited == false)
        {
            neighbors.Add(new CellAndRelativePosition(cells[x, y - 1], CellAndRelativePosition.Direction.North));
        }

        if (neighbors.Count == 0) return;
        neighbors.Shuffle();

        foreach(CellAndRelativePosition selectedcell in neighbors)
        {
            if(selectedcell.direction == CellAndRelativePosition.Direction.East)
            {
                if (selectedcell.cell.visited) continue;
                currentCell.East = true;
                selectedcell.cell.West = true;
                GenerateMaze(x + 1, y);
            }
            if (selectedcell.direction == CellAndRelativePosition.Direction.South)
            {
                if (selectedcell.cell.visited) continue;
                currentCell.South = true;
                selectedcell.cell.North = true;
                GenerateMaze(x, y + 1);
            }
            if (selectedcell.direction == CellAndRelativePosition.Direction.West)
            {
                if (selectedcell.cell.visited) continue;
                currentCell.West = true;
                selectedcell.cell.East = true;
                GenerateMaze(x - 1, y);
            }
            if (selectedcell.direction == CellAndRelativePosition.Direction.North)
            {
                if (selectedcell.cell.visited) continue;
                currentCell.North = true;
                selectedcell.cell.South = true;
                GenerateMaze(x, y - 1);
            }
        }
    }
    //instantiate prefabs based on cell / obstacle rules 
    void InitVisualCell()
    {
        foreach (Cell cell in cells)
        {

            if (cell.isObstacle)
            {
                int poop = Random.Range(0, obstacles.Length);
                visualCellInst = Instantiate(obstacles[poop], new Vector3(cell.xPos * 3, obstacles[poop].gameObject.transform.position.y, height * 3f - cell.zPos * 3), Quaternion.identity) as VisualCell;
                visualCellInst.transform.parent = transform;
                visualCellInst.North.gameObject.SetActive(!cell.North);
                visualCellInst.South.gameObject.SetActive(!cell.South);
                visualCellInst.East.gameObject.SetActive(!cell.East);
                visualCellInst.West.gameObject.SetActive(!cell.West);

                if (visualCellInst.GetComponent<obstacle1>() != null || visualCellInst.GetComponent<Obstacle4>()!=null)
                {
                    visualCellInst.GetComponent<Renderer>().material = obstacleFloor;
                }
                else {
                    visualCellInst.GetComponent<Renderer>().material = floorFinal;
                }
                
                visualCellInst.North.gameObject.GetComponent<Renderer>().material = wallFinal;
                visualCellInst.South.gameObject.GetComponent<Renderer>().material = wallFinal;
                visualCellInst.East.gameObject.GetComponent<Renderer>().material = wallFinal;
                visualCellInst.West.gameObject.GetComponent<Renderer>().material = wallFinal;

                visualCellInst.transform.name = cell.xPos.ToString() + "_" + cell.zPos.ToString();
                //visualCellInst.GetComponent<VisualCell>().RandomizeScale();


            }
            else {

                visualCellInst = Instantiate(visualCellPrefab, new Vector3(cell.xPos * 3, 0, height * 3f - cell.zPos * 3), Quaternion.identity) as VisualCell;
                visualCellInst.transform.parent = transform;
                visualCellInst.North.gameObject.SetActive(!cell.North);
                visualCellInst.South.gameObject.SetActive(!cell.South);
                visualCellInst.East.gameObject.SetActive(!cell.East);
                visualCellInst.West.gameObject.SetActive(!cell.West);


                visualCellInst.GetComponent<Renderer>().material = floorFinal;
                visualCellInst.North.gameObject.GetComponent<Renderer>().material = wallFinal;
                visualCellInst.South.gameObject.GetComponent<Renderer>().material = wallFinal;
                visualCellInst.East.gameObject.GetComponent<Renderer>().material = wallFinal;
                visualCellInst.West.gameObject.GetComponent<Renderer>().material = wallFinal;

                visualCellInst.transform.name = cell.xPos.ToString() + "_" + cell.zPos.ToString();
                //visualCellInst.GetComponent<VisualCell>().RandomizeScale();

            }
        }
    }
    //Create player spawner prefabs
    void InstantiateSpawnersPrefab() {

        GameObject cornerNW = GameObject.Find("0_0");
        GameObject cornerNE = GameObject.Find((width-1).ToString()+"_0");
        GameObject cornerSW = GameObject.Find("0_"+(height-1).ToString());
        GameObject cornerSE = GameObject.Find((width-1).ToString()+"_"+(height-1).ToString());


        GameObject[] corners = new GameObject[4];
        corners[0] = cornerNW;
        corners[1] = cornerNE;
        corners[2] = cornerSW;
        corners[3] = cornerSE;

       int[] cornersArray = MakeCorners();

        corners[cornersArray[0]].gameObject.GetComponent<Renderer>().material = startMat;
        corners[cornersArray[1]].gameObject.GetComponent<Renderer>().material = endMAt;
        /**
        corners[0].GetComponent<Renderer>().material = cornerMat;
        corners[1].GetComponent<Renderer>().material = cornerMat;
        corners[2].GetComponent<Renderer>().material = cornerMat;
        corners[3].GetComponent<Renderer>().material = cornerMat;
    **/

        GameObject corn_0 = Instantiate(playerSpawner, new Vector3(cornerNW.transform.position.x, 0, cornerNW.transform.position.z), Quaternion.identity);
        GameObject corn_1 = Instantiate(playerSpawner, new Vector3(cornerNE.transform.position.x, 0, cornerNE.transform.position.z), Quaternion.identity);
        GameObject corn_2 = Instantiate(playerSpawner, new Vector3(cornerSW.transform.position.x, 0, cornerSW.transform.position.z), Quaternion.identity);
        GameObject corn_3 = Instantiate(playerSpawner, new Vector3(cornerSE.transform.position.x, 0, cornerSE.transform.position.z), Quaternion.identity);

        GameObject[] SpawnCorners = new GameObject[4];
        SpawnCorners[0] = corn_0;
        SpawnCorners[1] = corn_1;
        SpawnCorners[2] = corn_2;
        SpawnCorners[3] = corn_3;

        SpawnCorners[cornersArray[0]].gameObject.GetComponent<SpawnPlayer>().SetSpawnType(true, false);
        SpawnCorners[cornersArray[1]].gameObject.GetComponent<SpawnPlayer>().SetSpawnType(false, true);



        FindObjectOfType<SpawnManager>().FindSpawners();
        FindObjectOfType<SpawnManager>().InstantiatePlayer();

    }


    //Deprecated, spawns a chest at any dead end
    void SpawnChests() {

        VisualCell[] cells = FindObjectsOfType<VisualCell>();



        foreach (VisualCell c in cells) {
            int count = 0;
            foreach (Transform child in c.transform)
            {
                
                if (child.gameObject.activeInHierarchy) {
                    count++;
                }

            }
            if (count >= 3)
            {
                Instantiate(chestPrefab, new Vector3(c.gameObject.transform.position.x, c.gameObject.transform.position.y+ .7f, c.gameObject.transform.position.z), Quaternion.identity);
                
            }
            
        }


    }

    int[] MakeCorners() {

        int startCorn = Random.Range(0, 4);
        int endCorn = Random.Range(0, 4);

        while (startCorn==endCorn) {
             startCorn = Random.Range(0, 4);
            endCorn = Random.Range(0, 4);

        }


       // Debug.Log(startCorn+ " start");
        //Debug.Log(endCorn + " end");
        int [] returnArray = new int[2];
        returnArray[0] = startCorn;
        returnArray[1] = endCorn;
        return returnArray;
    }
    void ChangeSkyBox() {
        RenderSettings.skybox = skyMaterials[Random.Range(0, skyMaterials.Length)];

    }
}
