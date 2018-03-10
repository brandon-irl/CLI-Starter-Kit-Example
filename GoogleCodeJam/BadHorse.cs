using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeJam
{

	public static class BadHorse
	{
		public static void SolveBadHorse(string pathToInput)
		{
			using (var reader = new StreamReader(pathToInput))
			{
				var numTestCases = int.Parse(reader.ReadLine());
				for (var testCase = 0; testCase < numTestCases; testCase++)
				{
					var numPairs = int.Parse(reader.ReadLine());
					var graph = new Graph();
					for (var pair = 0; pair < numPairs; pair++)
					{
						var names = reader.ReadLine().Split();
						foreach (var name in names)
							if (!graph.Villains.Contains(name))
								graph.Villains.Add(name);
						graph.Edges.Add(new Edge { VillainA = names[0], VillainB = names[1] });
					}
					Console.WriteLine($"Case #{testCase}: {graph.IsSeparable()}");
				}
			}
		}

		class Edge
		{
			public string VillainA;
			public string VillainB;

			public bool ReferencesVillain(string villain)
			{
				return VillainA == villain || VillainB == villain;
			}

			public string GetEnemy(string villain)
			{
				if (!this.ReferencesVillain(villain))
					throw new ArgumentException("This edge doesn't reference villain " + villain);

				if (this.VillainA == villain)
					return VillainB;
				else
					return VillainA;
			}

			public override bool Equals(object obj)
			{
				var edge = obj as Edge;
				if (edge == null)
					return false;

				return (edge.VillainA == this.VillainA || edge.VillainA == this.VillainB) && (edge.VillainB == this.VillainA || edge.VillainB == this.VillainB);
			}
		}

		class Graph
		{
			public HashSet<string> Villains = new HashSet<string>();
			public List<Edge> Edges = new List<Edge>();

			public bool IsSeparable()
			{
				var track = this.Villains
					.ToDictionary(_ => _, _ => false);

				foreach (var villain in this.Villains)
				{
					this.Edges
						.Where(_ => _.ReferencesVillain(villain))
						.ToList()
						.ForEach(_ => track[_.GetEnemy(villain)] = true);

					// TODO: more stuff here
				}
				return true;
			}
		}
	}
}
