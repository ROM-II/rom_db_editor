namespace RunesDataBase.Sql.World
{
    public partial class RoleData
    {
        public override string ToString()
            => RoleName.Replace("\0", string.Empty);
    }
}
