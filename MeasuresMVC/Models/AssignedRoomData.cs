using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasuresMVC.Models
{
	public class AssignedRoomData
	{
		public int RoomId { get; set; }
		public string Title { get; set; }
		public bool Assigned { get; set; }
	}
}