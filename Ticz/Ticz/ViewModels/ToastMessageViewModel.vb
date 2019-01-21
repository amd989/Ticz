﻿Imports GalaSoft.MvvmLight
Imports System.Threading

Public Class ToastMessageViewModel
    Inherits ViewModelBase
    Implements IDisposable

    Protected Overridable Overloads Sub Dispose(disposing As Boolean)

        If disposing Then
            ' dispose managed resources
            cts.Dispose()
        End If

        ' free native resources

    End Sub 'Dispose


    Public Overloads Sub Dispose() Implements IDisposable.Dispose

        Dispose(True)
        GC.SuppressFinalize(Me)

    End Sub 'Dispose

    Public Property popupTask As Task

    Public Property msg As String
        Get
            Return _msg
        End Get
        Set(value As String)
            _msg = value
            RaisePropertyChanged()
        End Set
    End Property
    Private Property _msg As String


    ''' <summary>
    ''' 'More important messages can override less important ones, but not the other way around. This way we can ensure that i.e. error messages are not accidentally cleared so that the user
    ''' will never see them
    ''' - 0 = STATUS (loading stuff)
    ''' - 1 = NOTIFICATION (i.e. device switched)
    ''' - 2 = ERROR (i.e. connection error)
    ''' </summary>
    ''' <returns></returns>
    Public Property msg_Priority As Integer

    Public ReadOnly Property IconPathGeometry As String
        Get
            Select Case isError
                Case True
                    Return "m 597.15147 1021.456 c -8.72773 -3.5989 -12.40178 -6.8088 -15.77945 -13.7861 -3.27878 -6.7731 -3.13742 -14.60606 0.41965 -23.25266 3.25771 -7.91892 125.21913 -219.87912 131.68879 -228.86569 2.31457 -3.21501 6.8185 -7.57438 10.00871 -9.6875 5.01793 -3.32374 6.92295 -3.84202 14.12179 -3.84202 7.19884 0 9.10386 0.51828 14.12179 3.84202 3.19021 2.11312 7.69413 6.47249 10.00871 9.6875 6.88745 9.56689 128.59091 221.29918 131.87277 229.42426 6.14047 15.20229 1.45227 28.00599 -12.87827 35.17119 l -7.5 3.75 -134.375 0.2917 -134.375 0.2916 -7.33449 -3.0243 z m 149.58166 -38.62277 c 17.3916 -7.26668 17.64272 -33.08864 0.39794 -40.9198 -17.331 -7.87033 -35.06785 6.59585 -31.48742 25.68115 0.99444 5.3008 7.26201 12.87306 12.56907 15.18549 4.93145 2.14877 13.44641 2.17321 18.52041 0.0531 z m 2.4597 -68.9362 c 0.52628 -4.8125 3.25254 -23.09375 6.05835 -40.625 2.96167 -18.50492 4.85197 -34.11294 4.5066 -37.21038 -0.73522 -6.59403 -5.83966 -14.54946 -11.07113 -17.25476 -6.29995 -3.25783 -17.6813 -2.70895 -23.48638 1.13266 -5.60184 3.70712 -10.08931 12.05312 -10.08931 18.76453 0 2.55351 1.96577 16.01654 4.36839 29.91785 3.41197 19.74141 8.13161 51.26251 8.13161 54.30868 0 0.24338 4.64062 0.27916 10.3125 0.0795 l 10.3125 -0.36305 0.95687 -8.75 z"
                Case False
                    Return "m 653.76938 1027.2491 c -0.4313 -0.6979 -1.43577 -1.034 -2.23214 -0.7468 -0.79638 0.2871 -2.43233 0.016 -3.63545 -0.603 -1.42161 -0.7312 -2.1875 -0.6566 -2.1875 0.2129 0 0.9506 -0.72376 0.9506 -2.5 0 -1.375 -0.7359 -2.5 -1.0171 -2.5 -0.625 0 0.3921 -1.19288 0.074 -2.65085 -0.7057 -2.03559 -1.0895 -2.43576 -1.0707 -1.72415 0.081 0.71161 1.1514 0.31144 1.1702 -1.72415 0.081 -1.45798 -0.7804 -2.65085 -1.0489 -2.65085 -0.5967 0 0.4521 -0.76261 0.1891 -1.6947 -0.5845 -0.93208 -0.7735 -3.39161 -1.604 -5.4656 -1.8455 -2.074 -0.2415 -5.0928 -1.365 -6.70844 -2.4966 -1.61564 -1.1316 -3.94012 -2.0575 -5.16552 -2.0575 -1.2254 0 -5.14301 -1.4063 -8.70581 -3.125 -3.5628 -1.7188 -7.21629 -3.125 -8.11887 -3.125 -0.90258 0 -1.64106 -0.5625 -1.64106 -1.25 0 -0.6875 -1.14265 -1.25 -2.53923 -1.25 -1.39658 0 -2.86301 -0.8438 -3.25874 -1.875 -0.39573 -1.0313 -1.75112 -1.875 -3.012 -1.875 -1.26087 0 -2.62283 -0.5345 -3.02659 -1.1878 -0.87452 -1.415 -19.1254 -16.31222 -19.98443 -16.31222 -0.57659 0 -5.42321 -4.96521 -11.9896 -12.28298 -5.43243 -6.05405 -15.54998 -20.51281 -19.39505 -27.71702 -2.01815 -3.78125 -4.09124 -7.0625 -4.60686 -7.29166 -0.51563 -0.22918 -0.9375 -1.4948 -0.9375 -2.8125 0 -1.31772 -0.5625 -2.39584 -1.25 -2.39584 -0.6875 0 -1.17475 -0.42188 -1.08277 -0.9375 0.33295 -1.8666 -1.76653 -9.13084 -2.82868 -9.78729 -0.5987 -0.37001 -1.08855 -2.01261 -1.08855 -3.65021 0 -1.6376 -0.50035 -3.28669 -1.11189 -3.66464 -0.61154 -0.37796 -1.39013 -2.52052 -1.7302 -4.76127 -0.34007 -2.24075 -1.51158 -8.04118 -2.60334 -12.88984 -2.10906 -9.36661 -2.78605 -30.00613 -1.39187 -42.43425 0.46275 -4.125 0.93981 -8.625 1.06015 -10 0.276 -3.15374 4.43153 -19.17091 5.83743 -22.5 0.58068 -1.375 2.27861 -5.59375 3.77319 -9.375 2.52047 -6.37672 6.81211 -15.50464 11.06316 -23.5303 0.97439 -1.83958 2.44548 -3.9072 3.26908 -4.5947 0.82359 -0.6875 4.45792 -5.1875 8.07628 -10 3.61836 -4.8125 8.75665 -10.77297 11.41842 -13.24549 2.66177 -2.47252 4.83959 -5.14439 4.83959 -5.9375 0 -0.7931 0.84375 -1.44201 1.875 -1.44201 1.03125 0 1.875 -0.5625 1.875 -1.25 0 -0.6875 0.64223 -1.25 1.42717 -1.25 0.78495 0 3.03984 -1.6875 5.01087 -3.75 1.97104 -2.0625 4.42256 -3.75 5.44783 -3.75 1.02527 0 1.86413 -0.5625 1.86413 -1.25 0 -0.6875 0.58602 -1.25 1.30227 -1.25 0.71624 0 2.48893 -1.10555 3.9393 -2.45678 1.45037 -1.35122 3.11435 -2.16177 3.69773 -1.80122 0.58339 0.36055 1.0607 0.0266 1.0607 -0.742 0 -0.76865 0.50356 -1.08633 1.11902 -0.70595 0.61546 0.38037 1.45524 -0.18458 1.86617 -1.25546 0.41093 -1.07087 1.25468 -1.63337 1.875 -1.25 0.62032 0.38338 1.46407 -0.17912 1.875 -1.25 0.41093 -1.07087 1.31363 -1.59695 2.00598 -1.16905 0.69236 0.4279 1.25883 0.1167 1.25883 -0.69156 0 -0.85415 1.04693 -1.19578 2.5 -0.81579 1.375 0.35957 2.5 0.14392 2.5 -0.47922 0 -0.62313 0.65883 -1.13297 1.46407 -1.13297 0.80524 0 2.49274 -0.93093 3.75 -2.06873 1.41689 -1.28227 2.28593 -1.50892 2.28593 -0.59619 0 0.97189 1.07576 0.76769 3.16401 -0.60059 1.74021 -1.14022 3.50166 -1.73548 3.91435 -1.32279 0.41269 0.41269 1.81835 0.17876 3.12369 -0.51984 1.30535 -0.69859 3.90326 -1.52581 5.77315 -1.83825 1.86989 -0.31244 7.05605 -1.37249 11.5248 -2.35566 10.46739 -2.30293 38.08054 -3.36741 39.90945 -1.5385 0.95406 0.95407 1.34055 0.89542 1.34055 -0.20343 0 -1.20389 0.60635 -1.21947 2.75275 -0.0708 2.11664 1.13279 2.86686 1.13089 3.24656 -0.008 0.32076 -0.96229 0.99875 -1.06628 1.93475 -0.29675 0.79252 0.65157 3.40969 1.54062 5.81594 1.97568 6.10435 1.10369 6.67301 1.26311 8.4375 2.36542 0.85937 0.53686 2.125 0.62847 2.8125 0.20357 0.6875 -0.42489 1.25 -0.20914 1.25 0.47946 0 0.6886 1.11317 1.03762 2.47371 0.77561 1.36055 -0.26202 2.76507 -0.005 3.12115 0.57117 0.35609 0.57616 3.46166 1.72269 6.90129 2.54784 3.43961 0.82515 6.25385 2.03987 6.25385 2.69937 0 0.6595 0.5625 0.85145 1.25 0.42655 0.6875 -0.42489 1.25 -0.24245 1.25 0.40544 0 0.97178 2.07348 2.02708 6.25 3.18093 0.34375 0.095 3.25641 1.71751 6.47259 3.60565 3.21617 1.88814 6.15752 3.43298 6.53633 3.43298 2.33632 0 34.49108 27.53117 34.49108 29.53154 0 0.31515 1.17818 1.8151 2.61817 3.33323 1.44 1.51812 4.356 5.29148 6.48 8.38523 2.12402 3.09375 4.1802 5.90668 4.56933 6.25094 0.38913 0.34427 1.74479 2.59427 3.0126 5 3.88135 7.36509 6.41469 11.84385 7.0699 12.49906 0.34375 0.34375 0.80939 1.46875 1.03476 2.5 0.22537 1.03125 1.14951 3.5625 2.05368 5.625 2.79323 6.3718 3.6012 8.66903 3.83891 10.91497 0.12604 1.19074 0.79122 2.87824 1.47821 3.75 0.68699 0.87177 1.60876 4.34078 2.04839 7.70892 0.43962 3.36813 1.46226 6.9227 2.27254 7.89901 0.88558 1.06706 1.52224 6.60187 1.59612 13.8761 0.0676 6.65555 0.5831 12.83808 1.14555 13.73895 0.5737 0.91889 0.33348 3.30174 -0.54723 5.42795 -1.30184 3.14293 -1.26904 3.9837 0.19209 4.92455 1.32759 0.85484 1.39314 1.37375 0.26589 2.10477 -0.82283 0.53363 -1.74894 3.76801 -2.058 7.1875 -0.30906 3.41951 -1.50918 10.15478 -2.66693 14.96728 -1.15777 4.8125 -2.17948 9.73437 -2.27051 10.9375 -0.091 1.20313 -0.56358 2.1875 -1.05016 2.1875 -0.48657 0 -1.26782 1.74449 -1.73612 3.87665 -0.4683 2.13215 -2.13065 6.77277 -3.6941 10.3125 -1.56346 3.53971 -3.19995 7.2796 -3.63664 8.31085 -0.43669 1.03125 -1.90659 3.5625 -3.26645 5.625 -1.35986 2.0625 -2.85283 4.59375 -3.3177 5.625 -1.07212 2.37831 -16.34132 22.4806 -19.03574 25.06105 -1.11186 1.06483 -2.64536 3.03358 -3.4078 4.375 -0.76242 1.34142 -1.97385 2.43895 -2.69203 2.43895 -0.7182 0 -2.73942 1.54688 -4.49159 3.4375 -1.75218 1.89062 -3.56853 3.4375 -4.03634 3.4375 -0.46781 0 -1.76029 1.04174 -2.87217 2.31499 -1.1119 1.27324 -3.92073 3.29314 -6.24185 4.48866 -2.32113 1.19553 -5.53773 3.66933 -7.148 5.49743 -1.80145 2.0452 -2.94297 2.6492 -2.96728 1.5701 -0.0267 -1.1861 -0.79497 -0.8827 -2.37362 0.9375 -1.28377 1.4802 -3.21932 2.6913 -4.30123 2.6913 -1.08191 0 -2.32042 0.5717 -2.75225 1.2704 -0.43182 0.6987 -1.30877 0.9467 -1.94877 0.5512 -0.63999 -0.3955 -1.16363 -0.149 -1.16363 0.548 0 0.6969 -1.92979 1.6291 -4.28841 2.0716 -2.35863 0.4425 -4.61338 1.6513 -5.01054 2.6863 -0.39716 1.035 -1.44407 1.6048 -2.32645 1.2662 -0.88239 -0.3386 -2.64801 0.1475 -3.92361 1.0803 -1.27561 0.9327 -2.7873 1.4067 -3.35931 1.0531 -0.57201 -0.3535 -2.14093 -0.054 -3.48648 0.6666 -1.34556 0.7201 -4.79666 1.6046 -7.66911 1.9655 -2.87245 0.3609 -6.4238 1.3061 -7.89187 2.1004 -1.46952 0.7951 -7.86606 1.4455 -14.23172 1.4471 -6.35938 0 -11.5625 0.3423 -11.5625 0.7571 0 1.4068 -5.54252 1.1809 -6.43447 -0.2623 -0.66649 -1.0784 -1.67319 -1.0759 -4.05638 0.01 -2.11029 0.9615 -3.432 1.0202 -3.95406 0.1754 z m 5.90997 -58.91695 c 0.91296 -0.18973 1.94119 -0.64174 2.28494 -1.00447 0.34375 -0.36273 3.01562 -1.71378 5.9375 -3.00234 2.92187 -1.28857 5.3125 -2.89236 5.3125 -3.564 0 -0.67164 1.99699 -3.53934 4.43774 -6.37266 6.24418 -7.2485 6.81226 -8.02574 6.81226 -9.32069 0 -0.63234 0.84375 -1.84995 1.875 -2.70581 1.03125 -0.85586 1.875 -2.56536 1.875 -3.79889 0 -1.23352 0.52319 -2.43027 1.16265 -2.65945 0.63946 -0.22916 1.34259 -2.10416 1.5625 -4.16666 0.3252 -3.04995 -0.0669 -3.75 -2.10015 -3.75 -1.64091 0 -2.63726 0.96648 -2.89944 2.8125 -0.21969 1.54688 -0.92281 2.8125 -1.5625 2.8125 -0.63969 0 -1.16306 1.03782 -1.16306 2.30626 0 1.26845 -1.18955 3.37783 -2.64345 4.6875 -1.4539 1.30969 -3.12747 3.64686 -3.71906 5.19374 -0.77542 2.02755 -2.09268 2.8125 -4.71979 2.8125 -3.26805 0 -3.69961 -0.47475 -4.18115 -4.59951 -0.55901 -4.78833 0.21006 -10.03078 3.63459 -24.77549 1.11772 -4.8125 2.16675 -10.15625 2.33116 -11.875 1.28681 -13.45199 2.21206 -19.56368 3.1337 -20.69931 0.59111 -0.72837 1.36852 -3.54087 1.72759 -6.25 0.35906 -2.70913 0.97426 -7.17569 1.3671 -9.92569 0.39283 -2.75 0.92911 -7.15166 1.19171 -9.78148 0.26261 -2.62981 1.15391 -5.59653 1.98066 -6.59271 0.82675 -0.99617 1.20164 -2.11277 0.83308 -2.48133 -0.36856 -0.36858 0.10712 -3.58936 1.05703 -7.1573 0.94994 -3.56796 1.73383 -6.61672 1.74199 -6.77504 0.0538 -1.04388 -10.2896 1.00609 -13.52921 2.68136 -2.17578 1.12514 -3.95595 1.49626 -3.95595 0.82471 0 -0.67153 -2.36573 -0.16181 -5.25718 1.13273 -2.89145 1.29453 -5.72859 2.06236 -6.30476 1.70627 -0.57616 -0.35608 -1.72606 -0.0894 -2.55531 0.59268 -0.82926 0.68206 -3.3014 1.51972 -5.49364 1.86148 -2.19224 0.34177 -4.65935 1.03762 -5.48247 1.54633 -0.82313 0.50873 -2.40448 1.02344 -3.51412 1.14383 -4.14893 0.45009 -8.89252 3.17961 -8.89252 5.11684 0 1.57777 0.79945 1.82968 3.75 1.18163 2.30524 -0.50631 3.75 -0.3189 3.75 0.48645 0 0.72055 0.84375 0.98631 1.875 0.59059 1.03125 -0.39574 1.875 -0.13474 1.875 0.57998 0 0.71473 1.16678 1.66983 2.59284 2.12244 2.32051 0.73651 2.51449 1.50024 1.84682 7.27174 -0.4103 3.54684 -1.06309 9.8238 -1.45064 13.9488 -0.38754 4.125 -1.29878 8.21671 -2.02496 9.09271 -0.72617 0.87599 -1.01031 1.9027 -0.63142 2.28159 0.37887 0.37889 0.18532 2.44466 -0.43013 4.59061 -0.61545 2.14595 -1.39947 6.18174 -1.74229 8.96842 -0.34281 2.78667 -1.17781 6.97488 -1.85553 9.30713 -0.67774 2.33226 -0.99305 4.6275 -0.7007 5.10054 0.29236 0.47305 -0.22659 3.73406 -1.1532 7.24671 -0.92663 3.51265 -1.40705 6.66436 -1.06761 7.0038 0.33943 0.33944 0.16558 1.34783 -0.38633 2.24085 -1.10711 1.79133 -1.12281 1.88468 -2.30686 13.70959 -0.6997 6.98789 -0.4444 8.92646 1.62337 12.32665 1.34951 2.21909 3.7717 4.72132 5.38265 5.5605 2.50467 1.30475 13.33715 1.54477 18.76905 0.41587 z m 23.81317 -158.27026 c 4.07378 -3.9483 5.62688 -6.45045 5.70479 -9.19088 0.0589 -2.07108 0.3814 -4.03992 0.71671 -4.37522 0.94557 -0.94558 -2.77451 -10.61813 -5.05138 -13.13405 -1.1197 -1.23726 -3.00476 -2.24956 -4.18903 -2.24956 -1.18427 0 -2.86475 -0.85734 -3.7344 -1.90521 -0.86965 -1.04786 -1.87113 -1.61524 -2.22553 -1.26084 -0.3544 0.3544 -1.39925 0.0179 -2.32188 -0.74785 -0.92783 -0.77003 -1.67751 -0.85854 -1.67751 -0.19806 0 0.65679 -1.26563 1.08805 -2.8125 0.95835 -1.54688 -0.1297 -4.30559 0.80805 -6.13046 2.0839 -1.82488 1.27584 -3.83068 2.31971 -4.45733 2.31971 -0.62665 0 -2.28021 2.10937 -3.67457 4.6875 -2.76423 5.11093 -3.98773 16.5625 -1.76955 16.5625 0.73942 0 1.34441 0.6284 1.34441 1.39645 0 0.76804 2.10937 3.46491 4.6875 5.99305 4.38916 4.30404 5.17456 4.59306 12.34024 4.54105 7.30477 -0.053 7.90726 -0.30223 13.25049 -5.48084 z"
                Case Else
                    Return "m 653.76938 1027.2491 c -0.4313 -0.6979 -1.43577 -1.034 -2.23214 -0.7468 -0.79638 0.2871 -2.43233 0.016 -3.63545 -0.603 -1.42161 -0.7312 -2.1875 -0.6566 -2.1875 0.2129 0 0.9506 -0.72376 0.9506 -2.5 0 -1.375 -0.7359 -2.5 -1.0171 -2.5 -0.625 0 0.3921 -1.19288 0.074 -2.65085 -0.7057 -2.03559 -1.0895 -2.43576 -1.0707 -1.72415 0.081 0.71161 1.1514 0.31144 1.1702 -1.72415 0.081 -1.45798 -0.7804 -2.65085 -1.0489 -2.65085 -0.5967 0 0.4521 -0.76261 0.1891 -1.6947 -0.5845 -0.93208 -0.7735 -3.39161 -1.604 -5.4656 -1.8455 -2.074 -0.2415 -5.0928 -1.365 -6.70844 -2.4966 -1.61564 -1.1316 -3.94012 -2.0575 -5.16552 -2.0575 -1.2254 0 -5.14301 -1.4063 -8.70581 -3.125 -3.5628 -1.7188 -7.21629 -3.125 -8.11887 -3.125 -0.90258 0 -1.64106 -0.5625 -1.64106 -1.25 0 -0.6875 -1.14265 -1.25 -2.53923 -1.25 -1.39658 0 -2.86301 -0.8438 -3.25874 -1.875 -0.39573 -1.0313 -1.75112 -1.875 -3.012 -1.875 -1.26087 0 -2.62283 -0.5345 -3.02659 -1.1878 -0.87452 -1.415 -19.1254 -16.31222 -19.98443 -16.31222 -0.57659 0 -5.42321 -4.96521 -11.9896 -12.28298 -5.43243 -6.05405 -15.54998 -20.51281 -19.39505 -27.71702 -2.01815 -3.78125 -4.09124 -7.0625 -4.60686 -7.29166 -0.51563 -0.22918 -0.9375 -1.4948 -0.9375 -2.8125 0 -1.31772 -0.5625 -2.39584 -1.25 -2.39584 -0.6875 0 -1.17475 -0.42188 -1.08277 -0.9375 0.33295 -1.8666 -1.76653 -9.13084 -2.82868 -9.78729 -0.5987 -0.37001 -1.08855 -2.01261 -1.08855 -3.65021 0 -1.6376 -0.50035 -3.28669 -1.11189 -3.66464 -0.61154 -0.37796 -1.39013 -2.52052 -1.7302 -4.76127 -0.34007 -2.24075 -1.51158 -8.04118 -2.60334 -12.88984 -2.10906 -9.36661 -2.78605 -30.00613 -1.39187 -42.43425 0.46275 -4.125 0.93981 -8.625 1.06015 -10 0.276 -3.15374 4.43153 -19.17091 5.83743 -22.5 0.58068 -1.375 2.27861 -5.59375 3.77319 -9.375 2.52047 -6.37672 6.81211 -15.50464 11.06316 -23.5303 0.97439 -1.83958 2.44548 -3.9072 3.26908 -4.5947 0.82359 -0.6875 4.45792 -5.1875 8.07628 -10 3.61836 -4.8125 8.75665 -10.77297 11.41842 -13.24549 2.66177 -2.47252 4.83959 -5.14439 4.83959 -5.9375 0 -0.7931 0.84375 -1.44201 1.875 -1.44201 1.03125 0 1.875 -0.5625 1.875 -1.25 0 -0.6875 0.64223 -1.25 1.42717 -1.25 0.78495 0 3.03984 -1.6875 5.01087 -3.75 1.97104 -2.0625 4.42256 -3.75 5.44783 -3.75 1.02527 0 1.86413 -0.5625 1.86413 -1.25 0 -0.6875 0.58602 -1.25 1.30227 -1.25 0.71624 0 2.48893 -1.10555 3.9393 -2.45678 1.45037 -1.35122 3.11435 -2.16177 3.69773 -1.80122 0.58339 0.36055 1.0607 0.0266 1.0607 -0.742 0 -0.76865 0.50356 -1.08633 1.11902 -0.70595 0.61546 0.38037 1.45524 -0.18458 1.86617 -1.25546 0.41093 -1.07087 1.25468 -1.63337 1.875 -1.25 0.62032 0.38338 1.46407 -0.17912 1.875 -1.25 0.41093 -1.07087 1.31363 -1.59695 2.00598 -1.16905 0.69236 0.4279 1.25883 0.1167 1.25883 -0.69156 0 -0.85415 1.04693 -1.19578 2.5 -0.81579 1.375 0.35957 2.5 0.14392 2.5 -0.47922 0 -0.62313 0.65883 -1.13297 1.46407 -1.13297 0.80524 0 2.49274 -0.93093 3.75 -2.06873 1.41689 -1.28227 2.28593 -1.50892 2.28593 -0.59619 0 0.97189 1.07576 0.76769 3.16401 -0.60059 1.74021 -1.14022 3.50166 -1.73548 3.91435 -1.32279 0.41269 0.41269 1.81835 0.17876 3.12369 -0.51984 1.30535 -0.69859 3.90326 -1.52581 5.77315 -1.83825 1.86989 -0.31244 7.05605 -1.37249 11.5248 -2.35566 10.46739 -2.30293 38.08054 -3.36741 39.90945 -1.5385 0.95406 0.95407 1.34055 0.89542 1.34055 -0.20343 0 -1.20389 0.60635 -1.21947 2.75275 -0.0708 2.11664 1.13279 2.86686 1.13089 3.24656 -0.008 0.32076 -0.96229 0.99875 -1.06628 1.93475 -0.29675 0.79252 0.65157 3.40969 1.54062 5.81594 1.97568 6.10435 1.10369 6.67301 1.26311 8.4375 2.36542 0.85937 0.53686 2.125 0.62847 2.8125 0.20357 0.6875 -0.42489 1.25 -0.20914 1.25 0.47946 0 0.6886 1.11317 1.03762 2.47371 0.77561 1.36055 -0.26202 2.76507 -0.005 3.12115 0.57117 0.35609 0.57616 3.46166 1.72269 6.90129 2.54784 3.43961 0.82515 6.25385 2.03987 6.25385 2.69937 0 0.6595 0.5625 0.85145 1.25 0.42655 0.6875 -0.42489 1.25 -0.24245 1.25 0.40544 0 0.97178 2.07348 2.02708 6.25 3.18093 0.34375 0.095 3.25641 1.71751 6.47259 3.60565 3.21617 1.88814 6.15752 3.43298 6.53633 3.43298 2.33632 0 34.49108 27.53117 34.49108 29.53154 0 0.31515 1.17818 1.8151 2.61817 3.33323 1.44 1.51812 4.356 5.29148 6.48 8.38523 2.12402 3.09375 4.1802 5.90668 4.56933 6.25094 0.38913 0.34427 1.74479 2.59427 3.0126 5 3.88135 7.36509 6.41469 11.84385 7.0699 12.49906 0.34375 0.34375 0.80939 1.46875 1.03476 2.5 0.22537 1.03125 1.14951 3.5625 2.05368 5.625 2.79323 6.3718 3.6012 8.66903 3.83891 10.91497 0.12604 1.19074 0.79122 2.87824 1.47821 3.75 0.68699 0.87177 1.60876 4.34078 2.04839 7.70892 0.43962 3.36813 1.46226 6.9227 2.27254 7.89901 0.88558 1.06706 1.52224 6.60187 1.59612 13.8761 0.0676 6.65555 0.5831 12.83808 1.14555 13.73895 0.5737 0.91889 0.33348 3.30174 -0.54723 5.42795 -1.30184 3.14293 -1.26904 3.9837 0.19209 4.92455 1.32759 0.85484 1.39314 1.37375 0.26589 2.10477 -0.82283 0.53363 -1.74894 3.76801 -2.058 7.1875 -0.30906 3.41951 -1.50918 10.15478 -2.66693 14.96728 -1.15777 4.8125 -2.17948 9.73437 -2.27051 10.9375 -0.091 1.20313 -0.56358 2.1875 -1.05016 2.1875 -0.48657 0 -1.26782 1.74449 -1.73612 3.87665 -0.4683 2.13215 -2.13065 6.77277 -3.6941 10.3125 -1.56346 3.53971 -3.19995 7.2796 -3.63664 8.31085 -0.43669 1.03125 -1.90659 3.5625 -3.26645 5.625 -1.35986 2.0625 -2.85283 4.59375 -3.3177 5.625 -1.07212 2.37831 -16.34132 22.4806 -19.03574 25.06105 -1.11186 1.06483 -2.64536 3.03358 -3.4078 4.375 -0.76242 1.34142 -1.97385 2.43895 -2.69203 2.43895 -0.7182 0 -2.73942 1.54688 -4.49159 3.4375 -1.75218 1.89062 -3.56853 3.4375 -4.03634 3.4375 -0.46781 0 -1.76029 1.04174 -2.87217 2.31499 -1.1119 1.27324 -3.92073 3.29314 -6.24185 4.48866 -2.32113 1.19553 -5.53773 3.66933 -7.148 5.49743 -1.80145 2.0452 -2.94297 2.6492 -2.96728 1.5701 -0.0267 -1.1861 -0.79497 -0.8827 -2.37362 0.9375 -1.28377 1.4802 -3.21932 2.6913 -4.30123 2.6913 -1.08191 0 -2.32042 0.5717 -2.75225 1.2704 -0.43182 0.6987 -1.30877 0.9467 -1.94877 0.5512 -0.63999 -0.3955 -1.16363 -0.149 -1.16363 0.548 0 0.6969 -1.92979 1.6291 -4.28841 2.0716 -2.35863 0.4425 -4.61338 1.6513 -5.01054 2.6863 -0.39716 1.035 -1.44407 1.6048 -2.32645 1.2662 -0.88239 -0.3386 -2.64801 0.1475 -3.92361 1.0803 -1.27561 0.9327 -2.7873 1.4067 -3.35931 1.0531 -0.57201 -0.3535 -2.14093 -0.054 -3.48648 0.6666 -1.34556 0.7201 -4.79666 1.6046 -7.66911 1.9655 -2.87245 0.3609 -6.4238 1.3061 -7.89187 2.1004 -1.46952 0.7951 -7.86606 1.4455 -14.23172 1.4471 -6.35938 0 -11.5625 0.3423 -11.5625 0.7571 0 1.4068 -5.54252 1.1809 -6.43447 -0.2623 -0.66649 -1.0784 -1.67319 -1.0759 -4.05638 0.01 -2.11029 0.9615 -3.432 1.0202 -3.95406 0.1754 z m 5.90997 -58.91695 c 0.91296 -0.18973 1.94119 -0.64174 2.28494 -1.00447 0.34375 -0.36273 3.01562 -1.71378 5.9375 -3.00234 2.92187 -1.28857 5.3125 -2.89236 5.3125 -3.564 0 -0.67164 1.99699 -3.53934 4.43774 -6.37266 6.24418 -7.2485 6.81226 -8.02574 6.81226 -9.32069 0 -0.63234 0.84375 -1.84995 1.875 -2.70581 1.03125 -0.85586 1.875 -2.56536 1.875 -3.79889 0 -1.23352 0.52319 -2.43027 1.16265 -2.65945 0.63946 -0.22916 1.34259 -2.10416 1.5625 -4.16666 0.3252 -3.04995 -0.0669 -3.75 -2.10015 -3.75 -1.64091 0 -2.63726 0.96648 -2.89944 2.8125 -0.21969 1.54688 -0.92281 2.8125 -1.5625 2.8125 -0.63969 0 -1.16306 1.03782 -1.16306 2.30626 0 1.26845 -1.18955 3.37783 -2.64345 4.6875 -1.4539 1.30969 -3.12747 3.64686 -3.71906 5.19374 -0.77542 2.02755 -2.09268 2.8125 -4.71979 2.8125 -3.26805 0 -3.69961 -0.47475 -4.18115 -4.59951 -0.55901 -4.78833 0.21006 -10.03078 3.63459 -24.77549 1.11772 -4.8125 2.16675 -10.15625 2.33116 -11.875 1.28681 -13.45199 2.21206 -19.56368 3.1337 -20.69931 0.59111 -0.72837 1.36852 -3.54087 1.72759 -6.25 0.35906 -2.70913 0.97426 -7.17569 1.3671 -9.92569 0.39283 -2.75 0.92911 -7.15166 1.19171 -9.78148 0.26261 -2.62981 1.15391 -5.59653 1.98066 -6.59271 0.82675 -0.99617 1.20164 -2.11277 0.83308 -2.48133 -0.36856 -0.36858 0.10712 -3.58936 1.05703 -7.1573 0.94994 -3.56796 1.73383 -6.61672 1.74199 -6.77504 0.0538 -1.04388 -10.2896 1.00609 -13.52921 2.68136 -2.17578 1.12514 -3.95595 1.49626 -3.95595 0.82471 0 -0.67153 -2.36573 -0.16181 -5.25718 1.13273 -2.89145 1.29453 -5.72859 2.06236 -6.30476 1.70627 -0.57616 -0.35608 -1.72606 -0.0894 -2.55531 0.59268 -0.82926 0.68206 -3.3014 1.51972 -5.49364 1.86148 -2.19224 0.34177 -4.65935 1.03762 -5.48247 1.54633 -0.82313 0.50873 -2.40448 1.02344 -3.51412 1.14383 -4.14893 0.45009 -8.89252 3.17961 -8.89252 5.11684 0 1.57777 0.79945 1.82968 3.75 1.18163 2.30524 -0.50631 3.75 -0.3189 3.75 0.48645 0 0.72055 0.84375 0.98631 1.875 0.59059 1.03125 -0.39574 1.875 -0.13474 1.875 0.57998 0 0.71473 1.16678 1.66983 2.59284 2.12244 2.32051 0.73651 2.51449 1.50024 1.84682 7.27174 -0.4103 3.54684 -1.06309 9.8238 -1.45064 13.9488 -0.38754 4.125 -1.29878 8.21671 -2.02496 9.09271 -0.72617 0.87599 -1.01031 1.9027 -0.63142 2.28159 0.37887 0.37889 0.18532 2.44466 -0.43013 4.59061 -0.61545 2.14595 -1.39947 6.18174 -1.74229 8.96842 -0.34281 2.78667 -1.17781 6.97488 -1.85553 9.30713 -0.67774 2.33226 -0.99305 4.6275 -0.7007 5.10054 0.29236 0.47305 -0.22659 3.73406 -1.1532 7.24671 -0.92663 3.51265 -1.40705 6.66436 -1.06761 7.0038 0.33943 0.33944 0.16558 1.34783 -0.38633 2.24085 -1.10711 1.79133 -1.12281 1.88468 -2.30686 13.70959 -0.6997 6.98789 -0.4444 8.92646 1.62337 12.32665 1.34951 2.21909 3.7717 4.72132 5.38265 5.5605 2.50467 1.30475 13.33715 1.54477 18.76905 0.41587 z m 23.81317 -158.27026 c 4.07378 -3.9483 5.62688 -6.45045 5.70479 -9.19088 0.0589 -2.07108 0.3814 -4.03992 0.71671 -4.37522 0.94557 -0.94558 -2.77451 -10.61813 -5.05138 -13.13405 -1.1197 -1.23726 -3.00476 -2.24956 -4.18903 -2.24956 -1.18427 0 -2.86475 -0.85734 -3.7344 -1.90521 -0.86965 -1.04786 -1.87113 -1.61524 -2.22553 -1.26084 -0.3544 0.3544 -1.39925 0.0179 -2.32188 -0.74785 -0.92783 -0.77003 -1.67751 -0.85854 -1.67751 -0.19806 0 0.65679 -1.26563 1.08805 -2.8125 0.95835 -1.54688 -0.1297 -4.30559 0.80805 -6.13046 2.0839 -1.82488 1.27584 -3.83068 2.31971 -4.45733 2.31971 -0.62665 0 -2.28021 2.10937 -3.67457 4.6875 -2.76423 5.11093 -3.98773 16.5625 -1.76955 16.5625 0.73942 0 1.34441 0.6284 1.34441 1.39645 0 0.76804 2.10937 3.46491 4.6875 5.99305 4.38916 4.30404 5.17456 4.59306 12.34024 4.54105 7.30477 -0.053 7.90726 -0.30223 13.25049 -5.48084 z"
            End Select
        End Get
    End Property

    Public Property isGoing As Boolean
        Get
            Return _isGoing
        End Get
        Set(value As Boolean)
            _isGoing = value
            RaisePropertyChanged("isGoing")
        End Set
    End Property
    Private Property _isGoing As Boolean

    Public Property isError As Boolean
        Get
            Return _isError
        End Get
        Set(value As Boolean)
            _isError = value
            RaisePropertyChanged("isError")
        End Set
    End Property

    Private Property _isError As Boolean
    Public Property secondsToShow As Integer

    Public cts As New CancellationTokenSource
    Public ct As CancellationToken = cts.Token

    Private Async Function ShowMessage(err As Boolean, message As String, priority As Integer, intSeconds As Integer, ct As CancellationToken) As Task
        Dim timeWaited As Integer
        While Not ct.IsCancellationRequested
            Await RunOnUIThread(Sub()
                                    isGoing = False
                                    msg = message.Replace(System.Environment.NewLine, " ")
                                    isError = err
                                    msg_Priority = priority
                                End Sub)
            If intSeconds > 0 Then
                If intSeconds * 1000 > timeWaited Then
                    timeWaited += 100
                    Await Task.Delay(100)
                Else
                    'Messages that are shown for a limited amount of time should always be cleared (hence forcing them with True parameter)
                    cts.Cancel(True)
                    msg_Priority = 0
                End If
            End If
        End While
        Await RunOnUIThread(Sub()
                                msg = ""
                                isGoing = True
                            End Sub)
    End Function


    ''' <summary>
    ''' Clears any Notifications
    ''' </summary>
    ''' <param name="forceClear">When forceClear is set to True, Clear will also remove any messages with msg_Priority 2 (error)</param>
    Public Sub Clear(Optional forceClear As Boolean = False)
        If ct.CanBeCanceled And (msg_Priority < 2 Or forceClear = True) Then
            cts.Cancel()
            msg_Priority = 0
        End If
    End Sub

    ''' <summary>
    ''' Updates the Notification with a new message
    ''' </summary>
    ''' <param name="err">True/False if the message is an Error Message</param>
    ''' <param name="message">Text of the Message</param>
    ''' <param name="priority">Sets the priority of the message. 0 for Status updates, 1 for Notifications, 2 for Error Messages</param>
    ''' <param name="ForceUpdate">Boolean to force an update, even if the priority of the message is lower than the current active one</param>
    ''' <param name="seconds">Amount of seconds to show the message before it disappears</param>
    ''' <returns></returns>
    Public Async Function Update(err As Boolean, message As String, priority As Integer, Optional ForceUpdate As Boolean = False, Optional seconds As Integer = 2) As Task
        WriteToDebug("ToasMessageViewModel.Update()", "executed")
        If ct.CanBeCanceled Then
            If (priority >= msg_Priority Or ForceUpdate = True) Then
                cts.Cancel()
                If priority > msg_Priority Then
                    'Await Task.Delay(300)
                End If

            Else
                Exit Function
            End If
        End If

        If (priority >= msg_Priority Or ForceUpdate = True) Then
            cts = New CancellationTokenSource
            ct = cts.Token
            popupTask = Await Task.Factory.StartNew(Function() ShowMessage(err, message, priority, seconds, ct), ct)
        End If
    End Function

    Public Sub New()
        isGoing = True
    End Sub
End Class