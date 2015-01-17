using UnityEngine;
using System.Collections;

public enum BlockType {
	Stone,
	Water,
	Rubber,
	Bedrock
};

public struct BlockData {
	
	public bool			    bouncy;
	public int				health;
	public bool				solid;
	public bool				indestructible;
	public string 			auxScript;
	
};

public class BlockTypes : MonoBehaviour {

	public BlockData initData(BlockType type){

		BlockData data;
		switch(type){
			case BlockType.Stone:
				data.bouncy = false;
				data.health = 2;
				data.solid = true;
				data.indestructible = false;
				data.auxScript = "Stone";
				break;
			case BlockType.Water:
				data.bouncy = false;
				data.health = 0;
				data.solid = false;
				data.indestructible = false;
				data.auxScript = "Water";
				break;
			case BlockType.Rubber:
				data.bouncy = true;
				data.health = 0;
				data.solid = true;
				data.indestructible = true;
				data.auxScript = "Rubber";
				break;
			case BlockType.Bedrock:
				data.bouncy = false;
				data.health = 0;
				data.solid = true;
				data.indestructible = true;
				data.auxScript = "Bedrock";
				break;
			default:
				data.bouncy = false;
				data.health = 1;
				data.solid = false;
				data.indestructible = false;
				data.auxScript = null;
				break;
		}
		return data;
	}

}