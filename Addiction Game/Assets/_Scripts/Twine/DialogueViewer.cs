using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DialogueObject;
using UnityEngine.Events;
 
public class DialogueViewer : MonoBehaviour {
    [SerializeField] Transform parentOfResponses;
    [SerializeField] Button prefab_btnResponse;
    [SerializeField] float yOffestBetweenResponseButtons = 20f;
    [Space]
    [SerializeField] SlowTyper txtMessage;
    [SerializeField] SlowTyper txtTitle;
    [SerializeField] Image imgMemory;
    [SerializeField] Button btnSpeedyProgress;
    [SerializeField] DialogueController controller;
    
 
    private void Start() {
        controller.onEnteredNode += OnNodeEntered;
        controller.InitializeDialogue();
        btnSpeedyProgress.onClick.AddListener( delegate {
            txtMessage.SpeedUp();
        } );
    }
 
    public static void KillAllChildren( UnityEngine.Transform parent ) {
        UnityEngine.Assertions.Assert.IsNotNull( parent );
        for ( int childIndex = parent.childCount - 1; childIndex >= 0; childIndex-- ) {
            UnityEngine.Object.Destroy( parent.GetChild( childIndex ).gameObject );
        }
    }
 
    private void OnNodeSelected( int indexChosen ) {
        Debug.Log( "Chose: " + indexChosen );
        controller.ChooseResponse( indexChosen );
    }
 
    private void OnNodeEntered( Node newNode ) {
        txtTitle.Clear();
        txtMessage.Clear();
        KillAllChildren( parentOfResponses );
 
        UnityAction typeResponsesAfterMessage = delegate {
            Vector3 curPos = parentOfResponses.position;
            for ( int i = newNode.responses.Count-1; i >= 0; i-- ) {
                int currentChoiceIndex = i;
                var response = newNode.responses[i];
                var responceButton = Instantiate( prefab_btnResponse, curPos, Quaternion.identity, parentOfResponses );
                curPos.y -= yOffestBetweenResponseButtons;
                responceButton.GetComponentInChildren<SlowTyper>().Begin(false, response.displayText);
                responceButton.onClick.AddListener( delegate { OnNodeSelected( currentChoiceIndex ); } );
            }
        };
 
        UnityAction typeMessageAfterTitle = delegate {
            txtMessage.Begin(false, newNode.text, typeResponsesAfterMessage );
        };
 
        UnityAction showMemoryAfterTitle = delegate {
            Debug.Log("Showing: " + newNode.title + ".jpg");
            Texture2D memoryTexture = Resources.Load<Texture2D>(newNode.title);
            Sprite memoryImage = Texture2DToSprite(memoryTexture);
            imgMemory.sprite = memoryImage;
            //imgMemory.GetComponent<Oscillate>().Begin();
            ShowContinueButton(typeMessageAfterTitle);
            txtMessage.Clear();
        };
 
        bool showMemoryBeforeMessage = newNode.tags.Contains( "Memory" );
        txtTitle.Begin(false, newNode.title, showMemoryBeforeMessage
            ? showMemoryAfterTitle : typeMessageAfterTitle );
    }
 
    public static Sprite Texture2DToSprite( Texture2D t ) {
        return Sprite.Create( t, new Rect( 0, 0, t.width, t.height ), new Vector2( 0.5f, 0.5f ) );
    }
 
    private void ShowContinueButton( UnityAction onContinuePressed ) {
        var responceButton = Instantiate( prefab_btnResponse, parentOfResponses );
        responceButton.GetComponentInChildren<SlowTyper>().Begin( false,"continue" );
        responceButton.onClick.AddListener( delegate {
            //imgMemory.GetComponent<Oscillate>().SetValue( Oscillate.ValueSet.Max );
            //imgMemory.GetComponent<Oscillate>().SetDirection( false );
            KillAllChildren( parentOfResponses );
            onContinuePressed();
        } );
    }
}
