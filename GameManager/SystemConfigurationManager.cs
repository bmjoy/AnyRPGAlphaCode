using AnyRPG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UMA;
using UMA.CharacterSystem;

namespace AnyRPG {
    public class SystemConfigurationManager : MonoBehaviour {

        #region Singleton
        private static SystemConfigurationManager instance;

        public static SystemConfigurationManager MyInstance {
            get {
                if (instance == null) {
                    instance = FindObjectOfType<SystemConfigurationManager>();
                }

                return instance;
            }
        }
        #endregion

        [Header("GAME CONFIGURATION")]

        [SerializeField]
        private string gameName;

        [SerializeField]
        private string gameVersion;

        [SerializeField]
        private List<string> loadResourcesFolders = new List<string>();


        [SerializeField]
        private float vendorPriceMultiplier = 0.25f;

        [Header("UI")]

        [SerializeField]
        private Material defaultCastingLightProjector;

        // default UI color for static elements that have no additional transparency applied to them
        [SerializeField]
        private Color defaultUIColor;

        // defaultUIColor with full opacity for button frames
        [SerializeField]
        private Color defaultUISolidColor;


        [SerializeField]
        private Color defaultUIFillColor;

        [SerializeField]
        private Sprite defaultUIPanelFrame;

        [SerializeField]
        private CurrencyGroup defaultCurrencyGroup;

        [Header("ANIMATION")]

        [SerializeField]
        private string defaultAttackClip;

        [SerializeField]
        private string defaultCastClip;

        [SerializeField]
        private string defaultMoveForwardClip;

        [SerializeField]
        private string defaultMoveForwardFastClip;

        [SerializeField]
        private string defaultCombatMoveForwardClip;

        [SerializeField]
        private string defaultCombatMoveForwardFastClip;

        [SerializeField]
        private string defaultMoveBackClip;

        [SerializeField]
        private string defaultMoveBackFastClip;

        [SerializeField]
        private string defaultCombatMoveBackClip;

        [SerializeField]
        private string defaultCombatMoveBackFastClip;

        [SerializeField]
        private string defaultJumpClip;

        [SerializeField]
        private string defaultCombatJumpClip;

        [SerializeField]
        private string defaultIdleClip;

        [SerializeField]
        private string defaultCombatIdleClip;

        [SerializeField]
        private string defaultLandClip;

        [SerializeField]
        private string defaultCombatLandClip;

        [SerializeField]
        private string defaultFallClip;

        [SerializeField]
        private string defaultCombatFallClip;

        [SerializeField]
        private string defaultStrafeLeftClip;

        [SerializeField]
        private string defaultJogStrafeLeftClip;

        [SerializeField]
        private string defaultStrafeRightClip;

        [SerializeField]
        private string defaultJogStrafeRightClip;

        [SerializeField]
        private string defaultStrafeForwardRightClip;

        [SerializeField]
        private string defaultJogStrafeForwardRightClip;

        [SerializeField]
        private string defaultStrafeForwardLeftClip;

        [SerializeField]
        private string defaultJogStrafeForwardLeftClip;

        [SerializeField]
        private string defaultStrafeBackLeftClip;

        [SerializeField]
        private string defaultJogStrafeBackLeftClip;

        [SerializeField]
        private string defaultStrafeBackRightClip;

        [SerializeField]
        private string defaultJogStrafeBackRightClip;

        [SerializeField]
        private string defaultCombatStrafeLeftClip;

        [SerializeField]
        private string defaultCombatJogStrafeLeftClip;

        [SerializeField]
        private string defaultCombatStrafeRightClip;

        [SerializeField]
        private string defaultCombatJogStrafeRightClip;

        [SerializeField]
        private string defaultCombatStrafeForwardRightClip;

        [SerializeField]
        private string defaultCombatJogStrafeForwardRightClip;

        [SerializeField]
        private string defaultCombatStrafeForwardLeftClip;

        [SerializeField]
        private string defaultCombatJogStrafeForwardLeftClip;

        [SerializeField]
        private string defaultCombatStrafeBackLeftClip;

        [SerializeField]
        private string defaultCombatJogStrafeBackLeftClip;

        [SerializeField]
        private string defaultCombatStrafeBackRightClip;

        [SerializeField]
        private string defaultCombatJogStrafeBackRightClip;

        [SerializeField]
        private string defaultStunnedClip;

        [SerializeField]
        private string defaultCombatStunnedClip;

        [SerializeField]
        private string defaultDeathClip;

        [SerializeField]
        private string defaultLevitatedClip;

        [SerializeField]
        private string defaultReviveClip;


        [Header("SYSTEM BAR")]


        [SerializeField]
        private Sprite systemBarMainMenu;

        [SerializeField]
        private Sprite systemBarAbilityBook;

        [SerializeField]
        private Sprite systemBarCharacter;

        [SerializeField]
        private Sprite systemBarQuestLog;

        [SerializeField]
        private Sprite systemBarMap;

        [Header("CHARACTER CONFIGURATION")]

        [SerializeField]
        private AnimationProfile defaultAttackAnimationProfile;

        [SerializeField]
        private RuntimeAnimatorController defaultAnimatorController;

        [SerializeField]
        private int maxLevel = 50;

        [SerializeField]
        private float weaponDPSBudgetPerLevel = 2.5f;

        [SerializeField]
        private float statBudgetPerLevel = 0f;

        [SerializeField]
        private float staminaStatBudgetPerLevel = 10f;

        [SerializeField]
        private float agilityStatBudgetPerLevel = 5f;

        [SerializeField]
        private float strengthStatBudgetPerLevel = 5f;

        [SerializeField]
        private float intellectStatBudgetPerLevel = 5f;

        // character units will automatically be set to this layer so they can respond to AOE / looting and other things that filter by this layer.
        [SerializeField]
        private string defaultCharacterUnitLayer = string.Empty;

        [Header("CHARACTER PANEL")]

        [SerializeField]
        private Sprite characterPanelHead;

        [SerializeField]
        private Sprite characterPanelShoulders;

        [SerializeField]
        private Sprite characterPanelChest;

        [SerializeField]
        private Sprite characterPanelHands;

        [SerializeField]
        private Sprite characterPanelLegs;

        [SerializeField]
        private Sprite characterPanelFeet;

        [SerializeField]
        private Sprite characterPanelMainHand;

        [SerializeField]
        private Sprite characterPanelOffHand;

        [Header("SYSTEM ABILITIES")]

        [SerializeField]
        private string levelUpAbilityName;

        private BaseAbility levelUpAbility;

        [SerializeField]
        private string deathAbilityName;

        private BaseAbility deathAbility;

        [SerializeField]
        private string lootSparkleAbilityName;

        private BaseAbility lootSparkleAbility;

        [SerializeField]
        private string doWhiteDamageAbilityName;

        private BaseAbility doWhiteDamageAbility;

        [SerializeField]
        private string takeDamageAbilityName;

        private BaseAbility takeDamageAbility;

        [SerializeField]
        private AudioClip defaultHitSoundEffect;

        [Header("INTERACTABLE CONFIGURATION")]

        [SerializeField]
        private Material temporaryMaterial = null;

        // an image to use if there is more than 1 valid interactable option
        [SerializeField]
        private Sprite multipleInteractionNamePlateImage;

        // a separate image if only crafting is available, but more than 1 craft skill can be shown
        [SerializeField]
        private Sprite multipleCraftNamePlateImage;

        [SerializeField]
        private Sprite bankInteractionPanelImage;

        [SerializeField]
        private Sprite bankNamePlateImage;

        [SerializeField]
        private Sprite questGiverInteractionPanelImage;

        [SerializeField]
        private Sprite questGiverNamePlateImage;

        [SerializeField]
        private Sprite dialogInteractionPanelImage;

        [SerializeField]
        private Sprite dialogNamePlateImage;

        [SerializeField]
        private Sprite nameChangeInteractionPanelImage;

        [SerializeField]
        private Sprite nameChangeNamePlateImage;

        [SerializeField]
        private Sprite cutSceneInteractionPanelImage;

        [SerializeField]
        private Sprite cutSceneNamePlateImage;

        [SerializeField]
        private Sprite lootableCharacterInteractionPanelImage;

        [SerializeField]
        private Sprite lootableCharacterNamePlateImage;

        [SerializeField]
        private Sprite characterCreatorInteractionPanelImage;

        [SerializeField]
        private Sprite characterCreatorNamePlateImage;

        [SerializeField]
        private Sprite unitSpawnControllerInteractionPanelImage;

        [SerializeField]
        private Sprite unitSpawnControllerNamePlateImage;

        [SerializeField]
        private Sprite factionChangeInteractionPanelImage;

        [SerializeField]
        private Sprite factionChangeNamePlateImage;

        [SerializeField]
        private Sprite classChangeInteractionPanelImage;

        [SerializeField]
        private Sprite classChangeNamePlateImage;

        [SerializeField]
        private Sprite vendorInteractionPanelImage;

        [SerializeField]
        private Sprite vendorNamePlateImage;

        [SerializeField]
        private Sprite portalInteractionPanelImage;

        [SerializeField]
        private Sprite portalNamePlateImage;

        [SerializeField]
        private Sprite skillTrainerInteractionPanelImage;

        [SerializeField]
        private Sprite skillTrainerNamePlateImage;

        [SerializeField]
        private Sprite musicPlayerInteractionPanelImage;

        [SerializeField]
        private Sprite musicPlayerNamePlateImage;

        // the default amount of time before a unit despawns after killed and looted
        [SerializeField]
        private float defaultDespawnTimer;

        protected bool eventSubscriptionsInitialized = false;

        public BaseAbility MyLootSparkleAbility { get => lootSparkleAbility; set => lootSparkleAbility = value; }
        public Material MyTemporaryMaterial { get => temporaryMaterial; set => temporaryMaterial = value; }
        public BaseAbility MyLevelUpAbility { get => levelUpAbility; set => levelUpAbility = value; }
        public Sprite MyQuestGiverInteractionPanelImage { get => questGiverInteractionPanelImage; set => questGiverInteractionPanelImage = value; }
        public Sprite MyQuestGiverNamePlateImage { get => questGiverNamePlateImage; set => questGiverNamePlateImage = value; }
        public Sprite MyDialogInteractionPanelImage { get => dialogInteractionPanelImage; set => dialogInteractionPanelImage = value; }
        public Sprite MyDialogNamePlateImage { get => dialogNamePlateImage; set => dialogNamePlateImage = value; }
        public Sprite MyNameChangeInteractionPanelImage { get => nameChangeInteractionPanelImage; set => nameChangeInteractionPanelImage = value; }
        public Sprite MyNameChangeNamePlateImage { get => nameChangeNamePlateImage; set => nameChangeNamePlateImage = value; }
        public Sprite MyCutSceneInteractionPanelImage { get => cutSceneInteractionPanelImage; set => cutSceneInteractionPanelImage = value; }
        public Sprite MyCutSceneNamePlateImage { get => cutSceneNamePlateImage; set => cutSceneNamePlateImage = value; }
        public Sprite MyLootableCharacterInteractionPanelImage { get => lootableCharacterInteractionPanelImage; set => lootableCharacterInteractionPanelImage = value; }
        public Sprite MyLootableCharacterNamePlateImage { get => lootableCharacterNamePlateImage; set => lootableCharacterNamePlateImage = value; }
        public Sprite MyCharacterCreatorInteractionPanelImage { get => characterCreatorInteractionPanelImage; set => characterCreatorInteractionPanelImage = value; }
        public Sprite MyCharacterCreatorNamePlateImage { get => characterCreatorNamePlateImage; set => characterCreatorNamePlateImage = value; }
        public Sprite MyFactionChangeInteractionPanelImage { get => factionChangeInteractionPanelImage; set => factionChangeInteractionPanelImage = value; }
        public Sprite MyFactionChangeNamePlateImage { get => factionChangeNamePlateImage; set => factionChangeNamePlateImage = value; }
        public Sprite MyClassChangeInteractionPanelImage { get => classChangeInteractionPanelImage; set => classChangeInteractionPanelImage = value; }
        public Sprite MyClassChangeNamePlateImage { get => classChangeNamePlateImage; set => classChangeNamePlateImage = value; }
        public Sprite MyPortalInteractionPanelImage { get => portalInteractionPanelImage; set => portalInteractionPanelImage = value; }
        public Sprite MyPortalNamePlateImage { get => portalNamePlateImage; set => portalNamePlateImage = value; }
        public Sprite MySkillTrainerInteractionPanelImage { get => skillTrainerInteractionPanelImage; set => skillTrainerInteractionPanelImage = value; }
        public Sprite MySkillTrainerNamePlateImage { get => skillTrainerNamePlateImage; set => skillTrainerNamePlateImage = value; }
        public AudioClip MyDefaultHitSoundEffect { get => defaultHitSoundEffect; set => defaultHitSoundEffect = value; }
        public BaseAbility MyDoWhiteDamageAbility { get => doWhiteDamageAbility; set => doWhiteDamageAbility = value; }
        public BaseAbility MyTakeDamageAbility { get => takeDamageAbility; set => takeDamageAbility = value; }
        public BaseAbility MyDeathAbility { get => deathAbility; set => deathAbility = value; }
        public Sprite MyMultipleInteractionNamePlateImage { get => multipleInteractionNamePlateImage; set => multipleInteractionNamePlateImage = value; }
        public float MyDefaultDespawnTimer { get => defaultDespawnTimer; set => defaultDespawnTimer = value; }
        public Sprite MyBankInteractionPanelImage { get => bankInteractionPanelImage; set => bankInteractionPanelImage = value; }
        public Sprite MyBankNamePlateImage { get => bankNamePlateImage; set => bankNamePlateImage = value; }
        public Sprite MyVendorInteractionPanelImage { get => vendorInteractionPanelImage; set => vendorInteractionPanelImage = value; }
        public Sprite MyVendorNamePlateImage { get => vendorNamePlateImage; set => vendorNamePlateImage = value; }
        public Sprite MyMultipleCraftNamePlateImage { get => multipleCraftNamePlateImage; set => multipleCraftNamePlateImage = value; }
        public string MyGameName { get => gameName; set => gameName = value; }
        public string MyGameVersion { get => gameVersion; set => gameVersion = value; }
        public Sprite MyCharacterPanelHead { get => characterPanelHead; set => characterPanelHead = value; }
        public Sprite MyCharacterPanelShoulders { get => characterPanelShoulders; set => characterPanelShoulders = value; }
        public Sprite MyCharacterPanelChest { get => characterPanelChest; set => characterPanelChest = value; }
        public Sprite MyCharacterPanelHands { get => characterPanelHands; set => characterPanelHands = value; }
        public Sprite MyCharacterPanelLegs { get => characterPanelLegs; set => characterPanelLegs = value; }
        public Sprite MyCharacterPanelFeet { get => characterPanelFeet; set => characterPanelFeet = value; }
        public Sprite MyCharacterPanelMainHand { get => characterPanelMainHand; set => characterPanelMainHand = value; }
        public Sprite MyCharacterPanelOffHand { get => characterPanelOffHand; set => characterPanelOffHand = value; }
        public Sprite MySystemBarMainMenu { get => systemBarMainMenu; set => systemBarMainMenu = value; }
        public Sprite MySystemBarAbilityBook { get => systemBarAbilityBook; set => systemBarAbilityBook = value; }
        public Sprite MySystemBarCharacter { get => systemBarCharacter; set => systemBarCharacter = value; }
        public Sprite MySystemBarQuestLog { get => systemBarQuestLog; set => systemBarQuestLog = value; }
        public Sprite MySystemBarMap { get => systemBarMap; set => systemBarMap = value; }
        public Sprite MyUnitSpawnControllerInteractionPanelImage { get => unitSpawnControllerInteractionPanelImage; set => unitSpawnControllerInteractionPanelImage = value; }
        public Sprite MyUnitSpawnControllerNamePlateImage { get => unitSpawnControllerNamePlateImage; set => unitSpawnControllerNamePlateImage = value; }
        public Sprite MyMusicPlayerInteractionPanelImage { get => musicPlayerInteractionPanelImage; set => musicPlayerInteractionPanelImage = value; }
        public Sprite MyMusicPlayerNamePlateImage { get => musicPlayerNamePlateImage; set => musicPlayerNamePlateImage = value; }
        public RuntimeAnimatorController MyDefaultAnimatorController { get => defaultAnimatorController; set => defaultAnimatorController = value; }
        public AnimationProfile MyDefaultAttackAnimationProfile { get => defaultAttackAnimationProfile; set => defaultAttackAnimationProfile = value; }
        public Material MyDefaultCastingLightProjector { get => defaultCastingLightProjector; set => defaultCastingLightProjector = value; }
        public Color MyDefaultUIColor { get => defaultUIColor; set => defaultUIColor = value; }
        public Color MyDefaultUIFillColor { get => defaultUIFillColor; set => defaultUIFillColor = value; }
        public string MyDefaultAttackClip { get => defaultAttackClip; set => defaultAttackClip = value; }
        public string MyDefaultCastClip { get => defaultCastClip; set => defaultCastClip = value; }
        public string MyDefaultReviveClip { get => defaultReviveClip; set => defaultReviveClip = value; }
        public Color MyDefaultUISolidColor { get => defaultUISolidColor; set => defaultUISolidColor = value; }
        public List<string> MyLoadResourcesFolders { get => loadResourcesFolders; set => loadResourcesFolders = value; }
        public string MyDefaultMoveForwardClip { get => defaultMoveForwardClip; set => defaultMoveForwardClip = value; }
        public string MyDefaultMoveForwardFastClip { get => defaultMoveForwardFastClip; set => defaultMoveForwardFastClip = value; }
        public string MyDefaultCombatMoveForwardClip { get => defaultCombatMoveForwardClip; set => defaultCombatMoveForwardClip = value; }
        public string MyDefaultCombatMoveForwardFastClip { get => defaultCombatMoveForwardFastClip; set => defaultCombatMoveForwardFastClip = value; }
        public string MyDefaultMoveBackClip { get => defaultMoveBackClip; set => defaultMoveBackClip = value; }
        public string MyDefaultMoveBackFastClip { get => defaultMoveBackFastClip; set => defaultMoveBackFastClip = value; }
        public string MyDefaultCombatMoveBackClip { get => defaultCombatMoveBackClip; set => defaultCombatMoveBackClip = value; }
        public string MyDefaultCombatMoveBackFastClip { get => defaultCombatMoveBackFastClip; set => defaultCombatMoveBackFastClip = value; }
        public string MyDefaultJumpClip { get => defaultJumpClip; set => defaultJumpClip = value; }
        public string MyDefaultCombatJumpClip { get => defaultCombatJumpClip; set => defaultCombatJumpClip = value; }
        public string MyDefaultIdleClip { get => defaultIdleClip; set => defaultIdleClip = value; }
        public string MyDefaultCombatIdleClip { get => defaultCombatIdleClip; set => defaultCombatIdleClip = value; }
        public string MyDefaultLandClip { get => defaultLandClip; set => defaultLandClip = value; }
        public string MyDefaultCombatLandClip { get => defaultCombatLandClip; set => defaultCombatLandClip = value; }
        public string MyDefaultFallClip { get => defaultFallClip; set => defaultFallClip = value; }
        public string MyDefaultCombatFallClip { get => defaultCombatFallClip; set => defaultCombatFallClip = value; }
        public string MyDefaultStrafeLeftClip { get => defaultStrafeLeftClip; set => defaultStrafeLeftClip = value; }
        public string MyDefaultJogStrafeLeftClip { get => defaultJogStrafeLeftClip; set => defaultJogStrafeLeftClip = value; }
        public string MyDefaultStrafeRightClip { get => defaultStrafeRightClip; set => defaultStrafeRightClip = value; }
        public string MyDefaultJogStrafeRightClip { get => defaultJogStrafeRightClip; set => defaultJogStrafeRightClip = value; }
        public string MyDefaultStrafeForwardRightClip { get => defaultStrafeForwardRightClip; set => defaultStrafeForwardRightClip = value; }
        public string MyDefaultJogStrafeForwardRightClip { get => defaultJogStrafeForwardRightClip; set => defaultJogStrafeForwardRightClip = value; }
        public string MyDefaultStrafeForwardLeftClip { get => defaultStrafeForwardLeftClip; set => defaultStrafeForwardLeftClip = value; }
        public string MyDefaultJogStrafeForwardLeftClip { get => defaultJogStrafeForwardLeftClip; set => defaultJogStrafeForwardLeftClip = value; }
        public string MyDefaultStrafeBackLeftClip { get => defaultStrafeBackLeftClip; set => defaultStrafeBackLeftClip = value; }
        public string MyDefaultJogStrafeBackLeftClip { get => defaultJogStrafeBackLeftClip; set => defaultJogStrafeBackLeftClip = value; }
        public string MyDefaultStrafeBackRightClip { get => defaultStrafeBackRightClip; set => defaultStrafeBackRightClip = value; }
        public string MyDefaultJogStrafeBackRightClip { get => defaultJogStrafeBackRightClip; set => defaultJogStrafeBackRightClip = value; }
        public string MyDefaultCombatStrafeLeftClip { get => defaultCombatStrafeLeftClip; set => defaultCombatStrafeLeftClip = value; }
        public string MyDefaultCombatJogStrafeLeftClip { get => defaultCombatJogStrafeLeftClip; set => defaultCombatJogStrafeLeftClip = value; }
        public string MyDefaultCombatStrafeRightClip { get => defaultCombatStrafeRightClip; set => defaultCombatStrafeRightClip = value; }
        public string MyDefaultCombatJogStrafeRightClip { get => defaultCombatJogStrafeRightClip; set => defaultCombatJogStrafeRightClip = value; }
        public string MyDefaultCombatStrafeForwardRightClip { get => defaultCombatStrafeForwardRightClip; set => defaultCombatStrafeForwardRightClip = value; }
        public string MyDefaultCombatJogStrafeForwardRightClip { get => defaultCombatJogStrafeForwardRightClip; set => defaultCombatJogStrafeForwardRightClip = value; }
        public string MyDefaultCombatStrafeForwardLeftClip { get => defaultCombatStrafeForwardLeftClip; set => defaultCombatStrafeForwardLeftClip = value; }
        public string MyDefaultCombatJogStrafeForwardLeftClip { get => defaultCombatJogStrafeForwardLeftClip; set => defaultCombatJogStrafeForwardLeftClip = value; }
        public string MyDefaultCombatStrafeBackLeftClip { get => defaultCombatStrafeBackLeftClip; set => defaultCombatStrafeBackLeftClip = value; }
        public string MyDefaultCombatJogStrafeBackLeftClip { get => defaultCombatJogStrafeBackLeftClip; set => defaultCombatJogStrafeBackLeftClip = value; }
        public string MyDefaultCombatStrafeBackRightClip { get => defaultCombatStrafeBackRightClip; set => defaultCombatStrafeBackRightClip = value; }
        public string MyDefaultCombatJogStrafeBackRightClip { get => defaultCombatJogStrafeBackRightClip; set => defaultCombatJogStrafeBackRightClip = value; }
        public string MyDefaultStunnedClip { get => defaultStunnedClip; set => defaultStunnedClip = value; }
        public string MyDefaultCombatStunnedClip { get => defaultCombatStunnedClip; set => defaultCombatStunnedClip = value; }
        public string MyDefaultDeathClip { get => defaultDeathClip; set => defaultDeathClip = value; }
        public string MyDefaultLevitatedClip { get => defaultLevitatedClip; set => defaultLevitatedClip = value; }
        public int MyMaxLevel { get => maxLevel; set => maxLevel = value; }
        public float MyStatBudgetPerLevel { get => statBudgetPerLevel; set => statBudgetPerLevel = value; }
        public CurrencyGroup MyDefaultCurrencyGroup { get => defaultCurrencyGroup; set => defaultCurrencyGroup = value; }
        public float MyVendorPriceMultiplier { get => vendorPriceMultiplier; set => vendorPriceMultiplier = value; }
        public float MyStaminaStatBudgetPerLevel { get => staminaStatBudgetPerLevel; set => staminaStatBudgetPerLevel = value; }
        public float MyAgilityStatBudgetPerLevel { get => agilityStatBudgetPerLevel; set => agilityStatBudgetPerLevel = value; }
        public float MyStrengthStatBudgetPerLevel { get => strengthStatBudgetPerLevel; set => strengthStatBudgetPerLevel = value; }
        public float MyIntellectStatBudgetPerLevel { get => intellectStatBudgetPerLevel; set => intellectStatBudgetPerLevel = value; }
        public float MyWeaponDPSBudgetPerLevel { get => weaponDPSBudgetPerLevel; set => weaponDPSBudgetPerLevel = value; }
        public string MyDefaultCharacterUnitLayer { get => defaultCharacterUnitLayer; set => defaultCharacterUnitLayer = value; }

        private void Start() {
            //Debug.Log("PlayerManager.Start()");
            CreateEventSubscriptions();
            //VerifySystemAbilities();
        }

        private void CreateEventSubscriptions() {
            //Debug.Log("PlayerManager.CreateEventSubscriptions()");
            if (eventSubscriptionsInitialized) {
                return;
            }
            eventSubscriptionsInitialized = true;
        }

        private void CleanupEventSubscriptions() {
            //Debug.Log("PlayerManager.CleanupEventSubscriptions()");
            if (!eventSubscriptionsInitialized) {
                return;
            }
            eventSubscriptionsInitialized = false;
        }

        public void OnDisable() {
            //Debug.Log("PlayerManager.OnDisable()");
            CleanupEventSubscriptions();
        }

        // verify that system abilities are available through the factory
        public void VerifySystemAbilities() {
            BaseAbility testAbility = null;
            if (levelUpAbilityName != null && levelUpAbilityName != string.Empty) {
                testAbility = SystemAbilityManager.MyInstance.GetResource(levelUpAbilityName);
                if (testAbility == null) {
                    Debug.LogError("SystemConfigurationManager.VerifySystemAbilities(): " + levelUpAbilityName + " COULD NOT BE FOUND IN FACTORY.  CHECK INSPECTOR");
                    return;
                } else {
                    levelUpAbility = testAbility;
                }
            }
            if (deathAbilityName != null && deathAbilityName != string.Empty) {
                testAbility = SystemAbilityManager.MyInstance.GetResource(deathAbilityName);
                if (testAbility == null) {
                    Debug.LogError("SystemConfigurationManager.VerifySystemAbilities(): " + deathAbilityName + " COULD NOT BE FOUND IN FACTORY.  CHECK INSPECTOR");
                    return;
                } else {
                    deathAbility = testAbility;
                }
            }
            if (lootSparkleAbilityName != null && lootSparkleAbilityName != string.Empty) {
                testAbility = SystemAbilityManager.MyInstance.GetResource(lootSparkleAbilityName);
                if (testAbility == null) {
                    Debug.LogError("SystemConfigurationManager.VerifySystemAbilities(): " + lootSparkleAbilityName + " COULD NOT BE FOUND IN FACTORY.  CHECK INSPECTOR");
                    return;
                } else {
                    lootSparkleAbility = testAbility;
                }
            }
            if (doWhiteDamageAbilityName != null && doWhiteDamageAbilityName != string.Empty) {
                testAbility = SystemAbilityManager.MyInstance.GetResource(doWhiteDamageAbilityName);
                if (testAbility == null) {
                    Debug.LogError("SystemConfigurationManager.VerifySystemAbilities(): " + doWhiteDamageAbilityName + " COULD NOT BE FOUND IN FACTORY.  CHECK INSPECTOR");
                    return;
                } else {
                    doWhiteDamageAbility = testAbility;
                }
            }
            if (takeDamageAbilityName != null && takeDamageAbilityName != string.Empty) {
                testAbility = SystemAbilityManager.MyInstance.GetResource(takeDamageAbilityName);
                if (testAbility == null) {
                    Debug.LogError("SystemConfigurationManager.VerifySystemAbilities(): " + takeDamageAbilityName + " COULD NOT BE FOUND IN FACTORY.  CHECK INSPECTOR");
                    return;
                } else {
                    takeDamageAbility = testAbility;
                }
            }
            if (defaultCurrencyGroup == null) {
                Debug.LogError("SystemConfigurationManager.VerifySystemAbilities(): NO DEFAULT CURRENCY GROUP SET.  CHECK INSPECTOR");
                return;
            }
            
            if (defaultAttackAnimationProfile == null) {
                Debug.LogError("SystemConfigurationManager.VerifySystemAbilities(): NO DEFAULT ATTACK ANIMATION PROFILE SET.  CHECK INSPECTOR");
                return;
            }
        }

    }

}