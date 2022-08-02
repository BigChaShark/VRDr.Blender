namespace DefaultNamespace
{
    public interface IDamage
    {
        public void IHit(int Damage);
        public void IPoison(int Speed);
        public void ReSpeed();
        public void IImpack(float Range);
        public void IFreeze(int Speed);
        public void IFire(int Damage, float DMGTime,float STSTime);
    }
}