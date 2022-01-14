namespace DotaWebCalculator.Models
{
    public class Hero
    {
        public int heroId { set; get; }
        public string heroName { set; get; }
        public int heroHealth { set; get; }
        public int heroMana { set; get; }
        public int heroStatRed { set; get; }
        public int heroStatGreen { set; get; }
        public int heroStatBlue { set; get; }
        public float heroArmor { set; get; }
        public int heroEvasion { set; get; }
        public int heroSpellAmp { set; get; }
        public int heroMagicRes { set; get; }
        public int heroStatusRes { set; get; }
        public int heroAttackSpeed { set; get; }
        public int heroAttackDmgLower { set; get; }
        public int heroAttackDmgHigher { set; get; }
        public string heroImage { set; get; }
    }
}
