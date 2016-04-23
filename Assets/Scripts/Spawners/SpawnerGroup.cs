namespace Space.Client
{
    public class SpawnerGroup : Spawner
    {
        public Spawner[] Spawners;

        protected override void SpawnInternal()
        {
            base.SpawnInternal();

            for (int i = 0, len = Spawners.Length; i < len; i++)
            {
                Spawners[i].Spawn();
            }
        }
    }
}