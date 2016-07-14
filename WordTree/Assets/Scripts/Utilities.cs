using UnityEngine;
using System;
using System.Collections;



namespace WordTree
{
	public class Utilities
	{
		//<summary>
		//stores information for camera settings
		//</summary>
		public static void setCameraViewForScreen()
		{
			//<summary>
			//set up camera view to reflect screen size
			//</summary>
			// game is designed for 16.0:9.0 aspect ratio
			float targetaspect = 16.0f / 9.0f;
			// determine the game window's current aspect ratio
			float windowaspect = (float)Screen.width / (float)Screen.height;
			//want game's current aspect ratio to match the target aspect ratio
			// current viewport height should be scaled by this amount
			float scaleHeight = windowaspect / targetaspect;
			// if scaleHeight is less than current height, create rectangle to so desired height:width ratio 
			//is created
			if (scaleHeight < 1.0f)
			{
				Rect rect = Camera.main.rect;
				rect.width = 1.0f;
				rect.height = scaleHeight;
				rect.x = 0;
				rect.y = (1.0f - scaleHeight) / 2.0f;
				Camera.main.rect = rect;
			}
			//if scaleHeight is greater or equal to current height, create rectangle so 
			//desired height:width ratio is created
			else 
			{
				float scalewidth = 1.0f / scaleHeight;
				Rect rect = Camera.main.rect;
				rect.width = scalewidth;
				rect.height = 1.0f;
				rect.x = (1.0f - scalewidth) / 2.0f;
				rect.y = 0;
				Camera.main.rect = rect;
			}
		}
	}
}