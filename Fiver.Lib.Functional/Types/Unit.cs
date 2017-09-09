namespace Fiver.Lib.Functional.Types
{
    public static class UnitFactory
    {
        private static readonly Unit unit = new Unit();
        public static Unit Unit() => unit;
    }

    public struct Unit
    {
        public override string ToString() => "Unit";
    }
}