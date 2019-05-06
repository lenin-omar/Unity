﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackOnce : MonoBehaviour
{
	public static TrackOnce instance;

	void Awake()
	{
		if ( instance == null )
		{
			instance = this;
		}
		else
		{
			DestroyImmediate( this.gameObject );
		}
	}

	public void IntroDone()
	{
		if ( MergeReticle.instance != null )
		{
			MergeReticle.instance.GameOverwrite( true, false );
		}
	}

	void Start()
	{
		if ( TitleScreenManager.instance != null )
		{
			TitleScreenManager.instance.OnTitleSequenceComplete += HandleTitleSequenceEnd;
			if ( MergeReticle.instance != null )
			{
				MergeReticle.instance.GameOverwrite( true, false );
			}
		}
		else
		{
			MergeMultiTarget.instance.OnTrackingFound += HandleTrackingFound;
			MergeMultiTarget.instance.OnTrackingLost += HandleTrackingLost;

			if ( MergeMultiTarget.instance.isTracking )
			{
				HandleTrackingFound();
			}
		}
	}

	void HandleTrackingFound()
	{
		this.transform.GetChild( 0 ).gameObject.SetActive( false );
		MergeMultiTarget.instance.OnTrackingFound -= HandleTrackingFound;
		MergeMultiTarget.instance.OnTrackingLost -= HandleTrackingLost;
		if ( MergeReticle.instance != null )
		{
			MergeReticle.instance.GameOverwrite( false, false );
		}
		DestroyImmediate( this.gameObject );
	}

	void HandleTrackingLost()
	{
		this.transform.GetChild( 0 ).gameObject.SetActive( true );

	}

	void HandleTitleSequenceEnd(bool isSwappingView)
	{
		TitleScreenManager.instance.OnTitleSequenceComplete -= HandleTitleSequenceEnd;

		MergeMultiTarget.instance.OnTrackingFound += HandleTrackingFound;
		MergeMultiTarget.instance.OnTrackingLost += HandleTrackingLost;

		if ( MergeMultiTarget.instance.isTracking )
		{
			HandleTrackingFound();
		}

	}
}
