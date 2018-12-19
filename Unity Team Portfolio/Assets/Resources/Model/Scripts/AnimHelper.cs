using UnityEngine;

public static class CGetClip
{
    public static AnimationClip GetClip(this Animator animator, string name)
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;

        for (int i = 0; i < clips.Length; ++i)
        {
            if (clips[i].name == name)
                return clips[i];
        }
        return null;
    }
}

public static class CGetExecTime
{
    public static float GetExecTime(this AnimationClip clip, int frame)
    {
        float totalFrame = (int)(clip.frameRate * clip.length) - 1; //시간 오버된 것이 반올림되는 경우가 있어서 그냥 1 빼준다.
        float frameTime = frame / totalFrame * clip.length;

        return frameTime;
    }

    //AnimationClip의 AddEvent를 오버라이드하는 효과가 있다. (인자에 this 확장기능을 붙였기 때문.)
    public static void AddEvent(this AnimationClip clip, string funcName, int frame)
    {
        float execTime = clip.GetExecTime(frame);
        //C#에서만 가능한 초기화 방법
        AnimationEvent e = new AnimationEvent()
        {
            time = execTime,
            functionName = funcName
        };
        clip.AddEvent(e);
    }
}