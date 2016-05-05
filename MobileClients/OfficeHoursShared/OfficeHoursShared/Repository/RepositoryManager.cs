using System;

namespace OfficeHoursShared
{
	public class RepositoryManager
	{

		public static IOfficeHoursRepository Repository;
		private static RepositoryManager instance;

		private RepositoryManager() {
			//throw new Exception("who called this constructor?!?");
		}

		public static RepositoryManager Instance
		{
			get 
			{
				if (instance == null)
				{
					throw new Exception("Object not created");
				}
				return instance;
			}
		}

		public static void CreateRepository(RepositoryType repoType, string userName)
		{
			if (instance != null)
			{
				throw new Exception("Object already created");
			}
			instance = new RepositoryManager ();

			if (repoType == RepositoryType.Mock) {
				MockRepository.Create(userName);
				Repository = MockRepository.Instance;
			}
				

		}
	}

	public enum RepositoryType {Mock, Rest};
}

