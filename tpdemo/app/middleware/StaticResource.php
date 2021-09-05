<?php
declare (strict_types = 1);

namespace app\middleware;

class StaticResource
{
    /**
     * 处理请求
     *
     * @param \think\Request $request
     * @param \Closure       $next
     * @return Response
     */
    public function handle($request, \Closure $next)
    {
        //
        $path=app()->getAppPath();

        /*if ($request->param('name') == 'think') {
            return redirect('index/think');
        }*/

        return $next($request);
    }
}
