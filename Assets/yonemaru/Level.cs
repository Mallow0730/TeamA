﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    //敵を殺すと手に入るポイントこれを一定数以上ためることでレベルが上がる、これがあるから敵を殺したくなるあと金
    public int _exp;
    //expをためることによって上がる、これによってステータスが上がる又はステータスポイントを手に入れ自分で割り振る
    public int _level = 1;
    //これは単純にレベル上げるのに必要なexp
    public int _levelup = 100;
    //UI用
    public Text _TextFrame;
    public Text _TextFrame2;
    bool _isFirstAction = false;
    void Start() {

    }

    
    //ただの確認用（Aキーを押して離したときexp100が手に入る）
    //Updateだから常に出力し続けてしまうのであとで戦闘終了時のみこの出力が流れるようにする　これは何とかなる
    void Update() 
        {
       // _TextFrame.text = string.Format();
        if (Input.GetKeyUp("a"))
            {
            _exp = _exp + 100000000;
        }//レベルを上げるのに必要な経験値の管理
        if ((_exp >= _levelup) && (_level <= 98))
            {
            _level++;
            if (_level <= 9) {
                _levelup = _levelup + 50 * _level;

            }
            else if (_level == 10) {
                _TextFrame.text = string.Format("レベルが10になった、レベルを上げるのに必要な経験値の上昇率が上がった");
                Debug.Log("レベルが10になった、レベルを上げるのに必要な経験値の上昇率が上がった");
                _levelup = _levelup + 100 * _level;
            }
            else if ((11 <= _level) && (_level <= 19)) {
                _levelup = _levelup + 100 * _level;
            }
            else if (_level == 20) 
                {
                _TextFrame.text = string.Format("レベルが20になった、レベルを上げるのに必要な経験値の上昇率がまた上がった");
                Debug.Log("レベルが20になった、レベルを上げるのに必要な経験値の上昇率がまた上がった");
                _levelup = _levelup + 150 * _level;
            }
            else if ((21 <= _level)&&(_level <= 49)) {
                _levelup = _levelup + 150 * _level;
            }
            else if(_level == 50) {
                _TextFrame.text = string.Format("レベルが50を超えた,レベルを上げるのに必要な経験値の上昇率が大幅に上がった");
                Debug.Log("レベルが50を超えた,レベルを上げるのに必要な経験値の上昇率が大幅に上がった");
                _levelup = _levelup + 500 * _level + 50;
            }
            else if (_level >= 99) { _TextFrame.text = string.Format("レベルが99になったんでこれ以上経験値集めても無駄だよ（たぶん、もしかしたらOverEXPスキルポイント還元システムとか追加されるかもね）"); Debug.Log("レベルが99になったんでこれ以上経験値集めても無駄だよ（たぶん）"); }else
            {
                _levelup = _levelup + 500 * _level;
            }
            _TextFrame2.text = string.Format("レベルが上がって" + _level + "になった");
            Debug.Log("レベルが上がって" + _level + "になった");
        }
    }
    //( ﾟ∀ﾟ)o彡゜えーりんえーりん
    //ゲームのBGMの中で砕月(緋想天の方が好きだったりするが萃夢想Arrangeが最強)(伊吹萃香)、英雄の証（メインテーマ）、ハートクエイク（トリエル）は個人的に別格
    //まあ、東方、モンハン、アンダーテールは全体的に素晴らしい、フルフル戦とかもはや最強だと思います。
    //ニーアの曲とかも好きだったが完走してデータ消した後もうやりたくないと思いました。パスカル村の話がきつかった、そうでなくとも3周目はきつかった
    //遊園地のBGMはとても素晴らしかった、ただしパレード防衛、テメーはダメだ
    //レースのサイドクエストスロー使えるの知ってたらもっと楽にクリアできたなと思いました。
    //実はリムワールドのBGMも結構好きだったりする
    //ゆっくり達のリムワールドはゆっくりで1話10分を100話以上（他のゲームの実況も10分を何個も）作ってるの凄いなと思いました。ゆっくりで3分動画作るだけで一時間かかることもあるのです
    //難易度はちょうどよかったダクソやセキロウ、仁王ほど難しくなかった、エルデンリングは知らん
    //あとはBBDcompanyのリムワールドも良かった、テラテックも好き、リムワールド第二期やってるの最高
    //オコジョ、エルチ,カヨシあたりのリムワールド実況も続きが見たい
    //のばまんまたリムワールドやんないかな、スズメバチとトロスヴァヌノォ再登場しないかな、断腸の思いで心臓の摘出してほしい
    //＃ハーフライフアリックスから逃げるな＃のばまん
    //話を戻して甘茶の音楽工房のフリーBGMのMomentと花祭りなどもすばらしい
    //あと魔王魂(シャイニングスターなど)やDova_syndrome(カエルのピアノなど)他にも良いのあるだろうけど分かんない,不老不死は何処のサイトの奴だろ
    //The Fat RatのUnityとかもいいよね
    //ドラクエ5やりすぎてモンスター仲間にできないのストレスヤベェ、FC(ファミコン(ファミリーコンピュータ))版のドラクエ6は魔物味方にできたらしいのに、DS以降のリメイク版だと仲間にできねぇ何だこの改悪
    //最近モンハンライズ始めたけど移動しながら武器を研ぐことができるのメッチャ楽、ガルクを沢山雇う意味が見当たらない
    //ハンターランク上限解放しないと重ね着作れなかったナルハタタヒメそんな強くなかった
    //双剣とチャアクあとは弓しか使えないから闘技場めちゃくちゃきつかった
    //早くライゼクスの装備が作りたいあとは闇布がほしい属性値全体的に低くね？
    //ワールドの時のベヒーモス的なのは居ないのだろうか、あと装飾品集めがメンドイ
    //全体的に雑に作ったから何かあったら直してもらって構わないです
    //幻想郷萃夜祭はやくステージ3以降出ないかな。そもそも出るのか？
    //追伸、上の文を書いたその日にお知らせで「一人で作ってるから時間かかってるけどあきらめてないしやめるつもりもないから待ってて」とのこと、良かった
    //東方LunaNight楽しい,サウザンドナイフめっちゃ強い
    //自動で戦ってくれる剣も良いけどテラリアの蝶倒すと出てくるボスを昼に倒したときにドロップするミニオンと違ってMp消費デカすぎるから使いどころは考えた方がいい
    //テラリアと言えばスカイシェルはまだ楽な方だし他にもアンクの盾やテラブーツ,ゼニスも作ったのに釣りクエで手に入るあと一つのアクセサリーが手に入らなくてPDA作れねぇ、クソが
    //最近弾幕神楽に愛き夜道追加されて嬉しい。天零萃夢やイノチ、温泉projectとかウィーアージャパニーズゴブリンも追加してくんないかな
    //天に月、地に花をも希望、何なら旧地獄街道を行くとかもほしい、ロスワ（東ロワ）の曲（だと思ってるけど知らん）になってしまうがα崩壊もほしい
    //そもそも、ロストワードクロニクルを追加していただきたい、なんかすごい号哭感を感じた、そしてYouTubeのコメントでそういうの書いてる人にArrange元の曲の方が先って言ってるけど、そっちには号哭感はなかった
    //東野幻想物語も原曲でもArrangeでもいいから追加してほしい、チルパも入ってるんだから魔理沙は大変なものを盗んでいきましたとか、スカーレット警察のゲッチューパトロールやスカーレットコールとかもほしい、レミリアが良いあと咲夜のあの感じ
    //↑追加されたけど東野幻想物語感がない、なんか砕月のArrangeの煕ル月、酔イシ花みたいな感じ、一応確かにその曲のArrangeだなとはなるけど他のArrangeと比べるとなんか違くね？ってなるやつ
    //スカ警がチックトックの曲だって言われているのが遺憾です,あと使うならサビの部分も入れてほしい、亡き王女の為のセプテットとおてんば恋娘をくっつけたサビはすごい好き、チックトックやってないからシステム的にできるのか知らないけどね
    //いつ追加されたか忘れたけどネイティブフェイスのArrangeが色んなextraのキャラのArrangeボスのマッシュアップの部分もありとても良い (https://youtu.be/P30vg1sa5Z8)
    //まだまだ続けるが星の器とか幻灯化とかニトリ旅とかもっと魂温泉の曲が欲しい
    //でも魂温泉の愛き夜道はたまの事もあったから追加されないのかなって思ってた
    //話を明後日の方向に飛ばしてリムワールドやりたい、最近スプラ2ばっかりでやってなかったし
    //スマブラは最近やってなさ過ぎてたぶん全部vip落ちしてるだろうし、下手になってそうだから正直やったら悲惨なことになりそう
    //スプラ2ワカバが一番使いやすいスプラッシュボムとアーマーと言ったとても強いサブスぺで塗もしやすい射程は正直ゴミだけど、とりあえずリッターﾀﾋね、あとスクイックリン、そしてヒッセンは普通に嫌い
    //サイン、コサイン、タングステン（タンジェントだった気もする）がマジで理解できてなかった
    //マイクラがMOD234こ入れて起動しようとすると5分位かかる、リムワールドも最近MOD増やしすぎて初回起動に10分近くかかる
    //sinθ cosθ tanθ θ(親方!!空から女の子がでお馴染みの降ってくる少女と同じ読み方)って何
    //フェアリーテイルのアクノロギアだけめっちゃ強かった、アクノロギアのせいでゴッドセレナがかませ犬に
    //たぶんゴッドセレナも強かったんだろうけどアクノロギアはフェアリーテイルの作中最強キャラだったから仕方ないね
    //フェアリーテイル読み終わってしまった、100年クエスト読んでる
    //100年クエスト読んでるとアクノロギアのヤバさが良く分かる
    //キングダムでは廉頗と信の再戦が見たい
    //飛信隊の死ん(家名.デスアスブリンガー)「選べ！死ぬか！戦うかだ！！」「コロス」と「ヨコセ」ぐらいしか語彙力内無いでしょ
    //パソコンとレンジ一緒に点けるとブレーカー落ちる
    //一万と二千年前から愛してる、八千年過ぎたころからもっと恋しくなった、一億と二千年後も愛してる
    //貴方は今どこで何をしていますか、この空の続く場所にいますか、いつものように笑顔でいてくれますか、今はただそれを願い続ける
    //知らないわこんな魔法、想いは伝えたら壊れちゃう
    //アンインストールアンインストールこの星の無数の塵の一つだと今の僕には理解できない、アンインストールアンインストール恐れを知らない戦士のように振舞うしかないアンインストール
    //すぐに呼びましょ陰陽師
    //この手を離すもんか真っ赤な誓い
    //見過ごしてた景色は億っ千万億っ千万
    //タイム連打も試してみたけど竜巻相手じゃ意味がない、だから次は絶対勝つために僕はE缶だけは最後まで取っておく
    //どんなに暗い世界の闇の中でさえきっとあなたは輝いて
    //DQ→FF　∑<(T-T７)ビシッ!!　右手を後ろに左手を掲げて敬礼してる感じにしたかった
    //ピッタンピッタン文字ピッタン
    //悪いがここから先は通行止めだ(これはイキってると思う)、残念だがこっから先は一方通行だ(見た目ひょろひょろだけどカッコ良く感じる、なんかバランスおかしいけど)
    //オルソラがメインヒロインでいいと思います
    //ブレワイが延期になったの辛い
    //アルカディアレコードそろそろリリースでは？
    //最近の音ゲー何か知らんけどキャラレベルとかキャラレア度とかあるんだけど、ロスワの絵札的なのもあるし、ダンカグとプロセカの事
    //エピック霊夢がいるのにエピック魔理沙まだ？赤魔理沙エピックに昇格しようぜぇ～
    //早くゆうかりんの転生来ないかな、豊姫の転生来たのは凄い嬉しかった
    //でも一番来てほしいのは伊吹萃香の転生だけどな
    //最近金がたまってきたしブレワイ2が出たらこの際ハードごと買おうかな
}
