﻿using Upgrade;
using Ship;
using Movement;

namespace UpgradesList.FirstEdition
{
    public class TwinIonEngineMkII : GenericUpgrade
    {
        public TwinIonEngineMkII() : base()
        {
            UpgradeInfo = new UpgradeCardInfo(
                "Twin Ion Engine Mk. II",
                UpgradeType.Modification,
                cost: 1,
                abilityType: typeof(Abilities.FirstEdition.TwinIonEngineMkIIAbility)
            );

            ImageUrl = ImageUrls.GetImageUrl(this, "twin-ion-engine-mkii");
        }
    }
}

namespace Abilities.FirstEdition
{
    public class TwinIonEngineMkIIAbility : GenericAbility
    {
        public override void ActivateAbility()
        {
            HostShip.AfterGetManeuverColorDecreaseComplexity += CheckAbility;
        }

        public override void DeactivateAbility()
        {
            HostShip.AfterGetManeuverColorDecreaseComplexity -= CheckAbility;
        }

        private void CheckAbility(GenericShip ship, ref ManeuverHolder movement)
        {
            if (movement.ColorComplexity != MovementComplexity.None)
            {
                if (movement.Bearing == ManeuverBearing.Bank)
                {
                    movement.ColorComplexity = MovementComplexity.Easy;
                }
            }
        }
    }
}