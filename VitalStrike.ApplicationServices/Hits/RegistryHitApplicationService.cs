using System.Transactions;
using VitalStrike.ApplicationServices.Models;
using VitalStrike.Domains;
using VitalStrike.Domains.Bodies.Exceptions;
using VitalStrike.Domains.Hits;
using VitalStrike.Domains.Users;
using VitalStrike.Domains.Users.Exceptions;
using VitalStrike.Models;

namespace VitalStrike.ApplicationServices.Hits;

/// <summary>
/// ヒット情報登録アプリケーションサービス
/// </summary>
public class RegistryHitApplicationService
{
    private readonly IHitRepository _repository;
    private readonly IUserRepository _userRepository;

    public RegistryHitApplicationService(IHitRepository repository,
                                            IUserRepository userRepository)
    {
        ArgumentNullException.ThrowIfNull(repository, nameof(repository));
        ArgumentNullException.ThrowIfNull(userRepository, nameof(userRepository));
        _repository = repository;
        _userRepository = userRepository;
    }

    /// <summary>
    /// ヒット情報を登録する
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="UserNotFoundException"></exception>
    /// <exception cref="BodyPartNotFoundException"></exception>
    public async Task<RegistryHitResponse> ExecuteAsync(RegistryHitRequest request)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        UserId attackerId = new UserId(request.AttackerId);
        User? attacker = await _userRepository.FetchAsync(attackerId);
        if (attacker == null) { throw new UserNotFoundException(attackerId); }

        UserId targetId = new UserId(request.TargetId);
        User? target = await _userRepository.FetchAsync(targetId);
        if (target == null) { throw new UserNotFoundException(targetId); }

        Domains.Bodies.BodyPart? hitZone = request.HitZone.ConvertTo();
        if (hitZone == null) { throw new BodyPartNotFoundException(); }

        HitPoint hitPoint = new HitPoint(x: (int)request.HitPoint.X, y: (int)request.HitPoint.Y);

        // TODO
        Damage damage = null!;
        bool isCritical;
        // ダメージ適用
        target.Vital.ApplyDamage(damage, (Domains.Bodies.BodyPart)hitZone, out isCritical);

        Hit hit = new Hit(attackerId, target, (Domains.Bodies.BodyPart)hitZone, hitPoint, damage, isCritical, request.HitAt);

        using (TransactionScope transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            HitId hitId = await _repository.SaveAsync(hit);

            transaction.Complete();

            return new RegistryHitResponse()
            {
                HitId = hitId.Value,
                Damage = damage.Value,
                IsCritical = isCritical,
                Target = new VitalStrike.Models.HP()
                {
                    Hp = target.Vital.TotalHP.Value,
                    Details = new BodyPartHP()
                    {
                        Face = target.Vital.Face.Hp.Value,
                        UpperBody = target.Vital.UpperBody.Hp.Value,
                        LeftArm = target.Vital.LeftArm.Hp.Value,
                        RightArm = target.Vital.RightArm.Hp.Value,
                        LeftHand = target.Vital.LeftHand.Hp.Value,
                        RightHand = target.Vital.RightHand.Hp.Value,
                        LeftLeg = target.Vital.LeftLeg.Hp.Value,
                        RightLeg = target.Vital.RightLeg.Hp.Value,
                        LeftFoot = target.Vital.LeftFoot.Hp.Value,
                        RightFoot = target.Vital.RightFoot.Hp.Value
                    }
                }
            };
        }
    }
}

