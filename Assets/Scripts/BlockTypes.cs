using UnityEngine;
using System.Collections;

public enum BlockType {
	Stone,
	Water,
	Lava,
	Rubber,
	Bedrock
};

public struct BlockData {
	
	public bool			    bouncy;
	public bool				solid;
	public bool				indestructible;
	public string 			auxScript;
	public string			tag;
	
};

public class BlockTypes : MonoBehaviour {

	public BlockData initData(BlockType type){

		BlockData data;

		data.tag = "Block";
		switch(type){
			case BlockType.Stone:
				data.bouncy = false;
				data.solid = true;
				data.indestructible = false;
				data.auxScript = "Stone";
				break;
			case BlockType.Water:
				data.bouncy = false;
				data.solid = false;
				data.indestructible = false;
				data.auxScript = "Water";
				break;
			case BlockType.Lava:
				data.bouncy = false;
				data.solid = false;
				data.indestructible = false;
				data.auxScript = "Lava";
				data.tag = "Lava";
				break;
			case BlockType.Rubber:
				data.bouncy = true;
				data.solid = true;
				data.indestructible = true;
				data.auxScript = "Rubber";
				break;
			case BlockType.Bedrock:
				data.bouncy = false;
				data.solid = true;
				data.indestructible = true;
				data.auxScript = "Bedrock";
				break;
			default:
				data.bouncy = false;
				data.solid = false;
				data.indestructible = false;
				data.auxScript = null;
				break;
		}
		return data;
	}

}