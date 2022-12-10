using System;
using System.Collections.Generic;

[Serializable]
public class Progress {
    public TimeSpan PastTime { private set; get; }
    public ushort ProgressLvl { private set; get; }

    public List<Type> ListUpgrade;

    public TimeSpan PreviousRecord;

    [NonSerialized]
    private DateTime _initialTime;

    public Progress(Progress ProgObj){
        _initialTime = DateTime.Now;
        PastTime = ProgObj.PastTime;
        ProgressLvl = ProgObj.ProgressLvl;
        ListUpgrade = ProgObj.ListUpgrade;
        PreviousRecord = ProgObj.PreviousRecord;
    }

    public Progress() {
        _initialTime = DateTime.Now;
        PastTime = TimeSpan.Zero;
        ProgressLvl = 1;
        ListUpgrade = new();
        PreviousRecord = TimeSpan.MaxValue;
    }

    public Progress(TimeSpan previousRecord) {
        _initialTime = DateTime.Now;
        PastTime = TimeSpan.Zero;
        ProgressLvl = 1;
        ListUpgrade = new();
        PreviousRecord = previousRecord;
    }

    public void FixTime() => PastTime += DateTime.Now - _initialTime;
    
    public void UpdateLevelCounter() => ++ProgressLvl;
}
