namespace DefaultNamespace
{
    public interface IDamage
    {
        public void IHit(int Damage);
        public void IPoison(int Damage);
        public void IImpack(int Damage,int Range);
        public void IFreeze(int Damge);
    }
}