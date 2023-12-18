//#region README �i#region���Ȃ����������Ȃ������@�v���؁j
// HLSL�̃e���v���[�g�i���쒆�AUnity��URP��z��j
// hlsl�t�@�C���ŏ������ƂŃR�[�h�G�f�B�^�̕⏕���󂯂邱�Ƃ��ł���
//
// �Q�lURL
// https://redhologerbera.hatenablog.com/entry/2022/03/08/215227
// https://redhologerbera.hatenablog.com/entry/2022/11/08/090356
// https://tips.hecomi.com/entry/2019/10/27/152520
//
// �iVisual Studio�̏ꍇ�j�g���@�\ HLSL Tools for Visual Studio ������Ə����₷��
// �������A
// https://tips.hecomi.com/entry/2020/12/20/000908
// https://tips.hecomi.com/entry/2023/02/25/163637
// �ŏ�����Ă���悤��Unity�ɑΉ����邽�߂̏��u���K�v
// �i�܂����Ă��Ȃ����ߗv���؁j
//
// �g���ۂ�Shader�t�@�C������
// #include  "TemplateHLSL.hlsl"
// �Ə���
//#endregion

// Shader�G���g���[�|�C���g
#pragma vertex vert		// vert	�͔C�ӂ̖��O�ɕύX�\
#pragma  fragment frag	// flag	�͔C�ӂ̖��O�ɕύX�\

// �C���N���[�h�i�ꕔ�̂݁j
// ShaderLab�̕��ɕK�v�Ȃ��̂̂ݏ����ċ@�\���g���������ق����ǂ�
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"
#include "Packages/com.unity.render-pipelines.universal/Shaders/UnlitInput.hlsl"
#include "Packages/com.unity.render-pipelines.universal/Shaders/LitInput.hlsl"
#include "Packages/com.unity.render-pipelines.universal/Shaders/DepthOnlyPass.hlsl"
#include "Packages/com.unity.render-pipelines.universal/Shaders/ShadowCasterPass.hlsl"

// ���_�V�F�[�_�[
struct appdata
{
	//3D���f������󂯎����i���_���W��uv���j���i�[�E�錾
};
v2f vert(appdata v)//���f���̒��_�Ɋւ��鏈�� Unity���W�ւ̕ϊ���
{
	v2f o;
	//����
	return o;
}

// �t���O�����g�V�F�[�_�[
struct v2f
{
	//���_�V�F�[�_�[�ł̏������ʂ��i�[����
	//��ʓI��Vertex to Fragment ��v2f
};
float4 frag(v2f i) :SV_Target
{
	//�R���s���[�^�̂P�s�N�Z�����Ƃ̐F����������
}