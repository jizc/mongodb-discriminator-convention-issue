namespace DiscriminatorConventionIssue.Types;

public class SetMemberUpdateAction
{
    public required string MemberName { get; set; }
    public object? Value { get; set; }
}
